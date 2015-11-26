namespace YekanPedia.ManagementSystem.Scheduler
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Web.Hosting;
    using System.Linq;
    public class SchedulerObserver : ISchedulerObserver
    {
        List<ScheduledTask> _tasks { get; set; }
        JobTimer _jobTimer = new JobTimer();
        int _disposed;
        Thread _taskThread;
        bool _isShuttingDown;
        readonly object _syncLock = new object();
        const int TimeToFinish = 30 * 1000;

        public SchedulerObserver()
        {
            _tasks = new List<ScheduledTask>();
            HostingEnvironment.RegisterObject(this);
            _jobTimer.StartTimer();
        }
        public void AddScheduledTask(IEnumerable<ScheduledTask> task)
        {
            _tasks.AddRange(task);
        }
        public void AddScheduledTask(ScheduledTask task)
        {
            _tasks.Add(task);
        }
        public IEnumerable<ScheduledTask> CurrentScheduledTask => _tasks;
        public void Start()
        {
            _jobTimer.CallBack = () =>
            {
                var now = DateTime.UtcNow;
                var tasks = _tasks.Where(x => !x.IsRunning && x.RunAt(now)).OrderBy(x => x.Order).ToList();
                if (_isShuttingDown || !tasks.Any())
                    return;
                _taskThread = new Thread(() => RunTask(tasks))
                {
                    Priority = ThreadPriority.BelowNormal,
                    IsBackground = true
                };
                _taskThread.Start();
            };
        }
        void RunTask(IEnumerable<ScheduledTask> tasks)
        {
            foreach (var scheduledTask in tasks)
            {
                try
                {
                    scheduledTask.IsRunning = true;
                    scheduledTask.LastRun = DateTime.UtcNow;
                    scheduledTask.Run();
                    scheduledTask.IsLastRunSuccessful = true;
                }
                catch (Exception ex)
                {
                    scheduledTask.IsLastRunSuccessful = false;
                }
                finally
                {
                    scheduledTask.IsRunning = false;
                }
            }
        }
        public void Stop()
        {
            _jobTimer.StopTimer();
        }
        public void Stop(bool immediate)
        {
            if (_isShuttingDown)
                return;
            lock (_syncLock)
            {
                _isShuttingDown = true;
                foreach (var scheduledTask in _tasks)
                {
                    scheduledTask.IsShuttingDown = true;
                }
                var timeOut = TimeToFinish;
                while (_tasks.Any(x => x.IsRunning) && timeOut >= 0)
                {
                    Thread.Sleep(50);
                    timeOut -= 50;
                }
                Dispose();
            }
        }
        public void Dispose()
        {
            if (Interlocked.Increment(ref _disposed) != 1)
                return;
            Stop();
            HostingEnvironment.UnregisterObject(this);
            GC.SuppressFinalize(this);
        }

     

        ~SchedulerObserver()
        {
            Dispose();
        }
    }
}

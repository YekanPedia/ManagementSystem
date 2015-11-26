namespace YekanPedia.ManagementSystem.Scheduler
{
    using System;
    using System.Threading;

    class JobTimer
    {
        Timer _timer;
        public void StartTimer()
        {
            _timer = new Timer(OnCallBackExecute, null, Timeout.Infinite, 1000);
            _timer.Change(1000, 1000);
        }
        public void StopTimer()
        {
            if (_timer != null)
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        public Action CallBack { get; set; }
        public void OnCallBackExecute(object state)
        {
            if (CallBack != null)
                CallBack();
        }
    }
}

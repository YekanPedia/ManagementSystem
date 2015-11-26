

namespace YekanPedia.ManagementSystem.Scheduler
{
    using System;

    public abstract class ScheduledTask
    {
        public abstract string Name { get; }
        public abstract int Order { get; }
        public abstract bool RunAt(DateTime utcNow);
        public abstract void Run();
        public bool IsRunning { set; get; }
        public bool IsShuttingDown { set; get; }
        public bool Pause { set; get; }
        public DateTime? LastRun { get; set; }
        public bool? IsLastRunSuccessful { get; set; }
    }
}

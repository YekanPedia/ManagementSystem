namespace YekanPedia.ManagementSystem.Scheduler
{
    using System;
    using Properties;
    using System.ComponentModel.DataAnnotations;

    public abstract class ScheduledTask
    {
        [Display(ResourceType = typeof(DisplayName), Name = nameof(Name))]

        public abstract string Name { get; }

        [Display(ResourceType = typeof(DisplayName), Name = nameof(Order))]
        public abstract int Order { get; }

        [Display(ResourceType = typeof(DisplayName), Name = nameof(ExecuteTime))]
        public abstract string ExecuteTime { get; }

        public abstract bool RunAt(DateTime utcNow);
        public abstract void Run();

        [Display(ResourceType = typeof(DisplayName), Name = nameof(IsRunning))]
        public bool IsRunning { set; get; }

        [Display(ResourceType = typeof(DisplayName), Name = nameof(IsShuttingDown))]
        public bool IsShuttingDown { set; get; }

        [Display(ResourceType = typeof(DisplayName), Name = nameof(Pause))]
        public bool Pause { set; get; }

        [Display(ResourceType = typeof(DisplayName), Name = nameof(LastRun))]
        public DateTime? LastRun { get; set; }

        [Display(ResourceType = typeof(DisplayName), Name = nameof(IsLastRunSuccessful))]
        public bool? IsLastRunSuccessful { get; set; }
    }
}

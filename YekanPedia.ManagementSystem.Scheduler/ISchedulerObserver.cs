
namespace YekanPedia.ManagementSystem.Scheduler
{
    using System;
    using System.Collections.Generic;
    using System.Web.Hosting;

    public interface ISchedulerObserver : IRegisteredObject, IDisposable
    {
        void AddScheduledTask(IEnumerable<ScheduledTask> task);
        void AddScheduledTask(ScheduledTask task);
        IEnumerable<ScheduledTask> CurrentScheduledTask { get; }
        void Stop();
        void Start();
    }
}

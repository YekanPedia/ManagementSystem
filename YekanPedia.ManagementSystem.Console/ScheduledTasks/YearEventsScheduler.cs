namespace YekanPedia.ManagementSystem.Console.ScheduledTasks
{
    using System;
    using Scheduler;
    using Elmah;
    using DependencyResolver;
    using Service.Interfaces;
    using System.Linq;
    using Domain.Entity;

    public class YearEventsScheduler : ScheduledTask
    {
        public override string ExecuteTime => "10:00 AM";
        public override string Name => "YearEvents";
        public override int Order => 4;
        public override void Run()
        {
            try
            {
                var _yearEventService = IocInitializer.GetInstance<IYearEventsService>();
                var events = _yearEventService.GetTodayEvents();
                if (events.Count() == 0)
                    return;

                var _userService = IocInitializer.GetInstance<IUserService>();
                var users = _userService.GetUsers();
                var _notificationService = IocInitializer.GetInstance<INotificationService>();
                foreach (var item in events)
                {
                    _notificationService.SendYearEventMessage(users.Result, NotificationType.YearEvent, item.Text);
                }
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
            }
        }
        public override bool RunAt(DateTime utcNow)
        {
            if (IsShuttingDown || Pause)
                return false;
            var now = utcNow.AddHours(3.5);
            return now.Hour == 10 && now.Minute == 00 && now.Second == 0;
        }
    }
}
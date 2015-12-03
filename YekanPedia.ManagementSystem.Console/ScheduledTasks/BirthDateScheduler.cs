
namespace YekanPedia.ManagementSystem.Console.ScheduledTasks
{
    using System;
    using Scheduler;
    using Elmah;
    using DependencyResolver;
    using Service.Interfaces;
    using System.Linq;

    public class BirthDateScheduler : ScheduledTask
    {
        public override string ExecuteTime => "11:00 AM";
        public override string Name => "BirthDate";
        public override int Order => 3;
        public override void Run()
        {
            try
            {
                var _userService = IocInitializer.GetInstance<IUserService>();
                var users = _userService.GetBirthDateUser();
                if (users.Count() > 0)
                {
                    var _notificationService = IocInitializer.GetInstance<INotificationService>();
                    _notificationService.SendNotificationToBirthDateUser(users);
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
            return now.Hour == 11 && now.Minute == 00 && now.Second == 0;
        }
    }
}
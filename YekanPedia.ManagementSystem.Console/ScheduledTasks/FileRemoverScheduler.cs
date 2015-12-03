namespace YekanPedia.ManagementSystem.Console.ScheduledTasks
{
    using System;
    using Scheduler;
    using System.Net;
    using DependencyResolver;
    using Service.Interfaces;
    using Elmah;

    public class FileRemoverScheduler : ScheduledTask
    {
        public override string ExecuteTime => "23:59 PM";
        public override string Name => "FileRemover";
        public override int Order => 2;
        public override void Run()
        {
            try
            {
                var _settingService = IocInitializer.GetInstance<ISettingService>();
                int day = 7;
                if (_settingService != null)
                {
                    var setting = _settingService.GetDefaultSetting();
                    if (setting != null)
                    {
                        day = setting.FilesPersistance;
                    }
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(AppSettings.FileRemoverUrl.Replace("{day}", day.ToString()));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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
            return now.Hour == 23 && now.Minute == 59;
        }
    }
}
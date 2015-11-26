namespace YekanPedia.ManagementSystem.Console.ScheduledTasks
{
    using System;
    using Scheduler;
    using System.Net;

    public class FileRemoverScheduler : ScheduledTask
    {
        public override string ExecuteTime => "23:59 PM";
        public override string Name => "FileRemover";
        public override int Order => 2;
        public override void Run()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(AppSettings.FileRemoverUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception e)
            {
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
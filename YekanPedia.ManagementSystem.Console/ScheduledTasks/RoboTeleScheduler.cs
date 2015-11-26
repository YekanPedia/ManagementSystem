namespace YekanPedia.ManagementSystem.Console.ScheduledTasks
{
    using System;
    using Scheduler;
    using System.Net;

    public class RoboTeleScheduler : ScheduledTask
    {
        public override string Name => "RoboTele";
        public override int Order => 1;
        public override void Run()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(AppSettings.RoboTeleUpdatesUrl);
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
            return now.Second % 2 == 0;
        }
    }
}
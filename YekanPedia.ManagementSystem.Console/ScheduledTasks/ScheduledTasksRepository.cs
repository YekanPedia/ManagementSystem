using System;
using System.Diagnostics;
using System.Net;
using YekanPedia.ManagementSystem.DependencyResolver;
using YekanPedia.ManagementSystem.Scheduler;

namespace YekanPedia.ManagementSystem.Console.ScheduledTasks
{
    public class ScheduledTasksRepository
    {
        public static void Init()
        {
            var observer = IocInitializer.GetInstance<ISchedulerObserver>();
            observer.AddScheduledTask(new RoboTeleScheduler());
            observer.AddScheduledTask(new FileRemoverScheduler());
            observer.Start();
        }
        public static void Dispose()
        {
            var observer = IocInitializer.GetInstance<ISchedulerObserver>();
            observer.Dispose();
        }
        public static void WakeUp(string pageUrl)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Credentials = CredentialCache.DefaultNetworkCredentials;
                    client.Headers.Add("User-Agent", "ScheduledTasks 1.0");
                    client.DownloadData(pageUrl);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}
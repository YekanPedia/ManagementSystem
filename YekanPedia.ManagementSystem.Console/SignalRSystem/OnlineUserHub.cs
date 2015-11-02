namespace YekanPedia.ManagementSystem.Console.SignalRSystem
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("OnlineUserHub")]
    public class OnlineUserHub : Hub
    {
        public void Online()
        {
            Clients.All.online();
        }
        public void Offline()
        {
            Clients.All.offline();
        }
    }
}
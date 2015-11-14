namespace YekanPedia.ManagementSystem.ExternalService.implement
{
    using Interfaces;
    using MessagingGateway;

    public class MessagingGatewayAdapter : IMessagingGatewayAdapter
    {
        readonly MessagingGatewayClient _messagingGatewayClinet;
        public MessagingGatewayAdapter()
        {
            _messagingGatewayClinet = new MessagingGatewayClient();
        }
        public void GivenMessages(NotificationPackage message)
        {
            _messagingGatewayClinet.GivenMessages(message);
        }
    }
}

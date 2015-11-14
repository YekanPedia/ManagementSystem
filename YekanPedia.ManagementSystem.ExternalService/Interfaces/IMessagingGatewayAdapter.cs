namespace YekanPedia.ManagementSystem.ExternalService.Interfaces
{
    using MessagingGateway;

    public interface IMessagingGatewayAdapter
    {
        void GivenMessages(NotificationPackage message);
    }
}

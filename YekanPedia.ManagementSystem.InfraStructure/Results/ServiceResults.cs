namespace YekanPedia.ManagementSystem.InfraStructure
{
    public class ServiceResults<TResult> : ActionResults, IServiceResults<TResult>
    {
        public TResult Result { get; set; }
    }
}

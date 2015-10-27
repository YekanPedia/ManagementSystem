namespace YekanPedia.ManagementSystem.InfraStructure
{
    public class ServiceResult<TResult> : ActionResult, IServiceResult<TResult>
    {
        public TResult Result { get; set; }
    }
}

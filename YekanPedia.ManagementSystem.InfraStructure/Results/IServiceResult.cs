namespace YekanPedia.ManagementSystem.InfraStructure
{
    public interface IServiceResult<TResult> : IActionResult
    {
        TResult Result { get; set; }
    }
}

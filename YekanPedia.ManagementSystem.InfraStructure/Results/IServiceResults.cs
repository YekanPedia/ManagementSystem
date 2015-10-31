namespace YekanPedia.ManagementSystem.InfraStructure
{
    public interface IServiceResults<TResult> : IActionResults
    {
        TResult Result { get; set; }
    }
}

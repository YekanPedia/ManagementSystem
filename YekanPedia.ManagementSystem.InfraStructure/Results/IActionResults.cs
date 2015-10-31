namespace YekanPedia.ManagementSystem.InfraStructure
{
    public interface IActionResults
    {
        bool IsSuccessfull { get; set; }
        string Message { get; set; }
    }
}

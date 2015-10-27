namespace YekanPedia.ManagementSystem.InfraStructure
{
    public interface IActionResult
    {
        bool IsSuccessfull { get; set; }
        string Message { get; set; }
    }
}

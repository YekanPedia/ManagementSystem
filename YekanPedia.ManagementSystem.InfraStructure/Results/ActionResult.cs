
namespace YekanPedia.ManagementSystem.InfraStructure
{
    public class ActionResult : IActionResult
    {
        public bool IsSuccessfull { get; set; }
        public string Message { get; set; }
    }
}

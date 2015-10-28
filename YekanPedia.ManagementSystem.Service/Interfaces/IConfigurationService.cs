namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using Domain.Entity;
    using System.Collections.Generic;

    public interface IConfigurationService
    {
        IEnumerable<Configuration> GetAllConfiguraion();
    }
}

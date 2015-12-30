namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using Domain.Entity;
    using InfraStructure;
    using System.Collections.Generic;

    public interface IYearEventsService
    {
        IServiceResults<int> Add(YearEvents model);
        IServiceResults<bool> Edit(YearEvents model);
        YearEvents Find(int yearEventsId);
        IEnumerable<YearEvents> GetYearEvents();
        IServiceResults<bool> Delete(int yearEventsId);
        IEnumerable<YearEvents> GetTodayEvents();
    }
}

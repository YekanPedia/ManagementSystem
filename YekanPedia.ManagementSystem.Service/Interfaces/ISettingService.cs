namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using Domain.Entity;
    using InfraStructure;

    public interface ISettingService
    {
        Setting GetDefaultSetting();
        IServiceResults<int> Edit(Setting model);
    }
}

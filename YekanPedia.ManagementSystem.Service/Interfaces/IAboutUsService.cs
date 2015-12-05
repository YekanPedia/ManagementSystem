namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using Domain.Entity;
    using InfraStructure;

    public interface IAboutUsService
    {
        AboutUs GetAboutUsInfo();
        IServiceResults<bool> Update(AboutUs model);
    }
}

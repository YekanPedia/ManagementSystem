namespace YekanPedia.ManagementSystem.Service.Implement
{
    using Domain.Entity;
    using Interfaces;
    using System.Data.Entity;
    using System.Linq;
    using Data.Context;
    using System;
    using InfraStructure;
    using Properties;

    public class AboutUsService : IAboutUsService
    {
        readonly IDbSet<AboutUs> _aboutUs;
        readonly IUnitOfWork _uow;
        public AboutUsService(IUnitOfWork uow)
        {
            _uow = uow;
            _aboutUs = _uow.Set<AboutUs>();
        }

        public AboutUs GetAboutUsInfo()
        {
            return _aboutUs.FirstOrDefault(X => X.AboutUsId == 1);
        }

        public IServiceResults<bool> Update(AboutUs model)
        {
            _aboutUs.Attach(model);
            _uow.Entry<AboutUs>(model).State = EntityState.Modified;
            var result = _uow.SaveChanges();
            return new ServiceResults<bool>()
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToBool() ? BusinessMessage.Ok : BusinessMessage.Error,
                Result = result.ToBool()
            };
        }
    }
}

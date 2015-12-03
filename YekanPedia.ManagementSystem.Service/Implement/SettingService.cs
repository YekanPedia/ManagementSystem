namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Linq;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;
    using System;
    using InfraStructure;
    using Properties;

    public class SettingService : ISettingService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<Setting> _setting;
        public SettingService(IUnitOfWork uow)
        {
            _uow = uow;
            _setting = uow.Set<Setting>();
        }
        #endregion
        public Setting GetDefaultSetting()
        {
            return _setting.FirstOrDefault(X => X.SettingId == 1);
        }

        public IServiceResults<int> Edit(Setting model)
        {
            _setting.Attach(model);
            _uow.Entry(model).State = EntityState.Modified;
            var resultSave = _uow.SaveChanges();
            return new ServiceResults<int>
            {
                IsSuccessfull = resultSave.ToBool(),
                Message = resultSave.ToMessage(BusinessMessage.Error),
                Result = model.SettingId
            };
        }
    }
}

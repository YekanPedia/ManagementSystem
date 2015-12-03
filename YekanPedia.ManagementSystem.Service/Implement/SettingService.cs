namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Linq;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;

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
    }
}

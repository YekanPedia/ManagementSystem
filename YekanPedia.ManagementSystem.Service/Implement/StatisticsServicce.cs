namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Linq;
    using Interfaces;
    using Domain.Poco;
    using Data.Context;
    using System.Data.Entity;
    using Domain.Entity;
    using System;
    using InfraStructure.Caching;

    public class StatisticsServicce : IStatisticsServicce
    {
        readonly IUnitOfWork _uow;
        readonly IDbSet<User> _user;
        readonly Lazy<ICacheProvider> _cache;
        public StatisticsServicce(IUnitOfWork uow, Lazy<ICacheProvider> cache)
        {
            _cache = cache;
            _uow = uow;
            _user = uow.Set<User>();
        }
        public UserStatistics GetUserStatistics()
        {
            var fromCache = _cache.Value.GetItem(nameof(this.GetUserStatistics));
            if (fromCache != null)
            {
                return (UserStatistics)(fromCache);
            }
            var date = DateTime.Now.AddDays(-20);
            var userlist = _user.Where(X => X.RegisterDate >= date).GroupBy(X => new { Year = X.RegisterDate.Year, Month = X.RegisterDate.Month, Day = X.RegisterDate.Day })
                        .Select(group => new
                        {
                            RegisterPersianDate = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.RegisterPersianDate);
            string studentCountList = string.Empty;
            foreach (var item in userlist)
            {
                studentCountList += $"{item.Count},";
            }
            studentCountList += "0";
            var data = new UserStatistics
            {
                CommentCount = "0",
                CommentCountList = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0",

                StudentCount = _user.Count(X => X.IsActive && X.IsTeacher == false).ToString(),
                StudentCountList = studentCountList,

                UserCount = _user.Count(X => X.IsActive).ToString(),
                UserCountList = studentCountList,

                WebSiteVisitCount = "0",
                WebSiteVisitCountList = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0",
            };
            _cache.Value.PutItem(nameof(this.GetUserStatistics), data, null, DateTime.Now.AddDays(5));
            return data;
        }
    }
}

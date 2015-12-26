namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Linq;
    using Interfaces;
    using Domain.Poco;
    using Data.Context;
    using System.Data.Entity;
    using Domain.Entity;
    using System;

    public class StatisticsServicce : IStatisticsServicce
    {
        readonly IUnitOfWork _uow;
        readonly IDbSet<User> _user;

        public StatisticsServicce(IUnitOfWork uow)
        {
            _uow = uow;
            _user = uow.Set<User>();
        }
        public UserStatistics GetUserStatistics()
        {
            var date = DateTime.Now.AddDays(-20);
            var userlist = _user.Where(X => X.RegisterDate >= date).GroupBy(X => new { Year = X.RegisterDate.Year, Month =X.RegisterDate.Month, Day =X.RegisterDate.Day} )
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

            return new UserStatistics
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
        }
    }
}

namespace YekanPedia.ManagementSystem.Data.Context
{
    using System.Data.Entity;
    using Domain.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Data.Entity.Infrastructure;
    using Elmah;

    public class ManagementSystemDbContext : DbContext, IUnitOfWork
    {
        public DbSet<User> User { get; set; }
        #region Overview
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Work> Work { get; set; }
        #endregion
        public DbSet<Tasks> Tasks { get; set; }
        #region Class
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassType> ClassType { get; set; }
        public DbSet<ClassTime> ClassTime { get; set; }
        public DbSet<UserInClass> UserInClass { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<ClassSession> ClassSession { get; set; }
        public DbSet<SessionRequest> SessionRequest { get; set; }
        #endregion
        #region Setting
        public DbSet<YearEvents> YearEvents { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<NotificationSetting> NotificationSetting { get; set; }
        #endregion
        public DbSet<Feedback> Feedback { get; set; }
        #region Role
        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ActionRole> ActionRole { get; set; }
        #endregion
        public DbSet<AboutUs> AboutUs { get; set; }
        #region Download
        public DbSet<StaticFiles> StaticFiles { get; set; }
        #endregion
        #region IELTS
        public DbSet<Book> Book { get; set; }
        public DbSet<ExamType> ExamType { get; set; }
          public DbSet<IeltsMaterial> IeltsMaterial { get; set; }
        public DbSet<Topic> Topic { get; set; }

        #endregion
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public override int SaveChanges()
        {
            try
            {
                //Auditing.Init(this);
                return base.SaveChanges();
            }
            catch (DbEntityValidationException validationException)
            {
                ErrorSignal.FromCurrentContext().Raise(validationException);
                return -1;
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                ErrorSignal.FromCurrentContext().Raise(concurrencyException);
                return -1;
            }
            catch (DbUpdateException updateException)
            {
                ErrorSignal.FromCurrentContext().Raise(updateException);
                return -1;
            }
        }
    }
}

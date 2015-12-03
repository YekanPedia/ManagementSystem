namespace YekanPedia.ManagementSystem.Data.Conext
{
    using System.Data.Entity;
    using Domain.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Data.Entity.Infrastructure;

    public class ManagementSystemDbContext : DbContext, IUnitOfWork
    {
        public DbSet<User> User { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassType> ClassType { get; set; }
        public DbSet<ClassTime> ClassTime { get; set; }
        public DbSet<NotificationSetting> NotificationSetting { get; set; }
        public DbSet<UserInClass> UserInClass { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<ClassSession> ClassSession { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<SessionRequest> SessionRequest { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ActionRole> ActionRole { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Setting> Setting { get; set; }

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
                foreach (var error in validationException.EntityValidationErrors)
                {
                    var entry = error.Entry;
                    foreach (var err in error.ValidationErrors)
                    {
                        Debug.WriteLine(err.PropertyName + " " + err.ErrorMessage);
                    }
                }
                return -1;
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                foreach (var entry in concurrencyException.Entries)
                {
                    Debug.WriteLine(entry.Entity);
                }
                return -1;
            }
            catch (DbUpdateException updateException)
            {
                if (updateException.InnerException != null)
                    Debug.WriteLine(updateException.InnerException.Message);
                foreach (var entry in updateException.Entries)
                {
                    Debug.WriteLine(entry.Entity);
                }
                return -1;
            }
        }
    }
}

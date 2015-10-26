namespace YekanPedia.ManagementSystem.Data.Conext
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Domain.Entity;

    public class ManagementSystemDbContext : DbContext, IUnitOfWork
    {
        public DbSet<User> User { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassType> ClassType { get; set; }
        public DbSet<ClassTime> ClassTime { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<UserInClass> UserInClass { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CanceledClass> CanceledClass { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}

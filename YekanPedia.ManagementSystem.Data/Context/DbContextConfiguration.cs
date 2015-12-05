namespace YekanPedia.ManagementSystem.Data.Context
{
    using System.Data.Entity;
    using Interception;

    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
           //AddInterceptor(new PersianCharactersInterceptor());
        }
    }
}

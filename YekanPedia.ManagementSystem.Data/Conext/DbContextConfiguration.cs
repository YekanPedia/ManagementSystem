namespace YekanPedia.ManagementSystem.Data.Conext
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

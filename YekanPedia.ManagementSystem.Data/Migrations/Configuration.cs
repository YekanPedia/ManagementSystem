namespace YekanPedia.ManagementSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Context;

   public sealed class Configuration : DbMigrationsConfiguration<ManagementSystemDbContext>
   {
       public Configuration()
       {
           AutomaticMigrationsEnabled = true;
           AutomaticMigrationDataLossAllowed = true;
       }
   
       protected override void Seed(ManagementSystemDbContext context)
       {
       }
   }
}

namespace Bibliobabel.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data.Seeder;

    internal sealed class Configuration : DbMigrationsConfiguration<Bibliobabel.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Bibliobabel.Data.ApplicationDbContext context)
        {
            var seeder = new Seeder();
            int numberOfUsers = 5;
            int numberOfPostsPerUser = 7;
            seeder.Create(numberOfUsers,numberOfPostsPerUser);
        }
    }
}

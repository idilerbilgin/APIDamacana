namespace APIDamacana.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using APIDamacana.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<APIDamacana.Models.APIDamacanaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(APIDamacana.Models.APIDamacanaContext context)
        {

            context.Products.AddOrUpdate(x => x.Id,
        new Product() { Id = 1, Name = "Erikli 19L", Price = 20 },
        new Product() { Id = 2, Name = "Sýrma 19L", Price = 17 },
        new Product() { Id = 3, Name = "Sýrma 15L", Price = 15 }
        );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

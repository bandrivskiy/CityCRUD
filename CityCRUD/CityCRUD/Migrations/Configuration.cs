namespace CityCRUD.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CityCRUD.DAL.CityDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CityCRUD.DAL.CityDBContext context)
        {
            context.Buildings.AddOrUpdate(new DAL.Building { Id = 1, Name = "Name1", Address = "I.Franka" , Allow = true});
            context.Buildings.AddOrUpdate(new DAL.Building { Id = 2, Name = "Name2", Address = "Rynok Square", Allow = false });
            context.Buildings.AddOrUpdate(new DAL.Building { Id = 3, Name = "Name3", Address = "Armenian", Allow = true });
            context.Buildings.AddOrUpdate(new DAL.Building { Id = 4, Name = "Name4", Address = "Lesi Ukrayinky, 8", Allow = false });

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

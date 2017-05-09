namespace FakeTravian.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FakeTravian.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FakeTravian.Models.ApplicationDbContext";
        }

        protected override void Seed(FakeTravian.Models.ApplicationDbContext context)
        {
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

            context.BuildingTypes.AddOrUpdate(
                p => p.Name,
                new Models.BuildingType { Name = "Garnary" },
                new Models.BuildingType { Name = "Barn" },
                new Models.BuildingType { Name = "Barracks" });

            var cities = context.Cities.ToList();

            foreach(var city in cities)
            {
                for(int i = 0; i < 10; i++)
                {
                    var building = city.Buildings.ElementAtOrDefault(i);
                    if(building == null)
                    {
                        building = new Models.Building { City = city };
                        city.Buildings.Add(building);
                    }
                }
            }
        }
    }
}

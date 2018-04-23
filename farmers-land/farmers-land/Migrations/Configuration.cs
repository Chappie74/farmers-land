namespace farmers_land.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<farmers_land.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "farmers_land.Models.ApplicationDbContext";
        }

        protected override void Seed(farmers_land.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //context.Roles.AddOrUpdate(r => r.Name,
            //    new IdentityRole { Name = "Farmer" },
            //    new IdentityRole { Name = "Consumer" },
            //    new IdentityRole { Name = "Admin" }
            //    );

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roles = { "Admin", "Farmer", "Consumer" };
            foreach (var role in roles)
            {
                if (!RoleManager.RoleExists(role))
                {
                    var roleResult = RoleManager.Create(new IdentityRole(role));
                }
            }
             
        }
    }
}

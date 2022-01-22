namespace Gym.Migrations
{
    using Gym.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gym.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gym.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            //IList<Trainier> trainers = new List<Trainier>();

            //trainers.Add(new Trainier() { FirstName = "Griselda", LastName = "Duka" });

            //context.Trainiers.AddRange(trainers);

            //context.Trainers.Add(new Trainer() { FirstName = "Griselda", LastName = "Duka", ExperienceDescription = "This is a test!", ImageName = "Ska" });

            //string[] roles = new string[] { "Admin" };

            //foreach (string role in roles)
            //{
            //    if (!context.Roles.Any(r => r.Name == role))
            //    {
            //        context.Roles.Add(new IdentityRole(role));
            //    }
            //}

            //foreach (string role in roles)
            //{
            //    var existingRole = context.Roles.FirstOrDefault(r => r.Name == role);
            //    if (existingRole == null)
            //    {
            //        context.Roles.Add(new IdentityRole(role));
            //    }
            //}

        }


    }
}

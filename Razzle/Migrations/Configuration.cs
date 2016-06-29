namespace Razzle.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Razzle.DAL.RazzleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Razzle.DAL.RazzleContext context)
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

            context.GameResults.AddOrUpdate(x => x.GameResultId,
                new GameResult() { GameResultId = 1, Player = "Jon Bon Jovi", Points = 8 },
                new GameResult() { GameResultId = 1, Player = "Al Franken", Points = 6 }

                );
        }
    }
}

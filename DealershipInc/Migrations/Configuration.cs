namespace DealershipInc.Migrations
{
    using DealershipInc.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DealershipInc.Models.DealershipDBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DealershipInc.Models.DealershipDBEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Customers.AddOrUpdate(x => x.CustomerID,
            new Customer() { CustomerID = 1, PhoneNum = 713-999-9999, FullName = "Luis Sierra" },
            new Customer() { CustomerID = 2, PhoneNum = 713-999-8888, FullName = "Charles Dickens" },
            new Customer() { CustomerID = 3, PhoneNum = 713-999-7777, FullName = "Miguel de Cervantes" },
            new Customer() { CustomerID = 4, PhoneNum = 713-999-6666, FullName = "Josh Smith" },
            new Customer() { CustomerID = 5, PhoneNum = 713-999-5555, FullName = "Mary Sanders" },
            new Customer() { CustomerID = 6, PhoneNum = 713-999-4444, FullName = "Carl Sierra" }
            );

          

        }
    }
}

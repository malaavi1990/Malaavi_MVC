using System.Collections;
using System.Collections.Generic;
using MalaaviMVC_DomainClasses.Users;

namespace MalaaviMVC_DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MalaaviMVC_DataLayer.Context.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MalaaviMVC_DataLayer.Context.DataContext context)
        {
            context.Roles.AddOrUpdate(
                new Role() { Name = "Admin", Title = "مدیر سایت" },
                new Role() { Name = "User", Title = "کاربر عادی" });

        }
    }
}

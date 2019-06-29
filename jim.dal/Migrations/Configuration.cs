namespace jim.dal.Migrations
{
    using jim.Dal.entities.Autentificacion;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<jim.dal.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(jim.dal.ApplicationDbContext context)
        {

            string userName = "jimovellan@gmail.com";
            string email = "jimovellan@gmail.com";
            string roleName = "Admin";
            string password = "jim@1980";

            var roleService = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new ApplicationDbContext()));
            var userService = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            
            var user = userService.FindByEmail(email);

            if (user == null)
            {
              var result =   userService.Create(new ApplicationUser() { UserName = userName, Email = email }, password);
               
            }

            if (!roleService.RoleExists("Admin"))
            {
                roleService.Create(new ApplicationRole() { Name = roleName });
                var u = userService.FindByEmail("jimovellan@gmail.com");
                userService.AddToRole(u.Id, "Admin");
            }
        }
    }
}

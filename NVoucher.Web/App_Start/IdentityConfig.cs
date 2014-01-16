using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NVoucher.Model;
using NVoucher.Web.Models;


namespace NVoucher.Web.App_Start
{


        public class DefaultDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
            {
                InitializeIdentityForEF(context);
                base.Seed(context);
            }

            private void InitializeIdentityForEF(ApplicationDbContext context)
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var profile = new Profile() { FirstName = "David", LastName = "salami", Country = "Uk", Term = true, Numbers =  07930694988};
                string name = "Admin";
                string password = "123456";
                string test = "test";

                //Create Role Test and User Test
                RoleManager.Create(new IdentityRole(test));
                UserManager.Create(new ApplicationUser() { UserName = test });

                //Create Role Admin if it does not exist
                if (!RoleManager.RoleExists(name))
                {
                    var roleresult = RoleManager.Create(new IdentityRole(name));
                }

                //Create User=Admin with password=123456
                var user = new ApplicationUser {UserName = name};
                var adminresult = UserManager.Create(user, password);

                //Add User Admin to Role Admin
                if (adminresult.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, name);
                }
            }
        }

 }

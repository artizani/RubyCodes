using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVoucher.Data;
using NVoucher.Model;
using Profile = NVoucher.Data.Profile;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new ApplicationDbContext();
            test.Users.Add(adduser());
            var all = test.Balances.Add(addbalance());
            test.SaveChanges();
          // get();
          Console.WriteLine(all.ToString());
            
        }

        public static Profile add()
        {
            return new Profile
            {
                FirstName = "David",
                LastName = "Salami",
                Country = "uk",
                Term = true,
                Numbers = 090909,
                IsVerified = false,
                Email = "olusal2@hotmail.com",
               
            };
        }


        public static void get()
        {
            var test = new ApplicationDbContext();
            var all = test.Balances.Count();
            //var all = test
            Console.WriteLine(all.ToString());
        }

        private static ApplicationUser adduser()
        {
           return new ApplicationUser
            {
                FirstName = "Olu",
                LastName = "Olusal",
                Country ="Uk",
                UserName = "Davidaa",
                PasswordHash = "erwqretqrtqqrfr",
                Term = false,
                IsVerified = false,
                Numbers = (int) 079694988


            }
            ;
        }

         private static Balance addbalance()
        {
           return new Balance
            {
                ApplicationUserId = "b62c1b75-1476-4ea5-aa57-523db32819f2",
                 InFlight= "1",
                Value ="4000",
                DateTime = DateTime.UtcNow
             


            }
            ;
        }

        
    }
}

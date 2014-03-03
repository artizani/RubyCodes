using System;
using Microsoft.Practices.Unity;
using NVoucher.Data;
using NVoucher.Model;
using NVoucher.Web;
using NVoucher.Web.Utils;
using Xunit;
using Profile = NVoucher.Data.Profile;

namespace Tester
{
    class EntityFrameworkTest
    {
        private UnityContainer container;
        public EntityFrameworkTest()
        {
            container = new UnityContainer();
            UnityInjection.WithSqlServerStorage(container);
        }
        [Dependency] public IUnitOfWork Work { get; set; }


        [Fact]
        public static Balance addbalance()
        {
            return new Balance
            {
                ApplicationUserId = "b62c1b75-1476-4ea5-aa57-523db32819f2",
                InFlight = "1",
                Value = "2000",
                DateTime = DateTime.UtcNow



            }
                ;

        }

        [Fact]
        public  void AddProfile()
        {
            var test = new ApplicationDbContext();
            test.Profiles.Add(
                new Profile
                {
                    FirstName = "David",
                    LastName = "Salami",
                    Country = "uk",
                    Term = true,
                    Numbers = 090909,
                    IsVerified = false,
                    Email = "olusal3@hotmail.com"

                });
            test.SaveChanges();

        }

        [Fact]
        public void AddUser()
        {
           
          

            var test = new ApplicationDbContext();
            test.Users.Add(
                new ApplicationUser
                {

                    FirstName = "Olu",
                    LastName = "Olusal",
                    Country = "Uk",
                    UserName = "Davidos",
                    PasswordHash = "erwqretqrtqqrfr",
                    Term = false,
                    IsVerified = false,
                    Numbers = (int)079694977

                });
            test.SaveChanges();


        }

        [Fact]
        public void AddBalance()
        {


            this.Work = container.Resolve<IUnitOfWork>();
            this.Work.BalanceRepository.Insert(
                new Balance
                {
                    ApplicationUserId = "b62c1b75-1476-4ea5-aa57-523db32819f949",
                    DateTime = DateTime.UtcNow,
                    InFlight = "0",
                    Value = 10.ToString()

                });
            this.Work.Save();


        }
        
    }
}

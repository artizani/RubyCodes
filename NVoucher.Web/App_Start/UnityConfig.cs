using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using NVoucher.Web.Utils;

namespace NVoucher.Web
{
    public static class UnityConfig
    {
        public static void InitialiseSqlServer(HttpConfiguration httpConfiguration)
        {
            var container = new UnityContainer();

            var factory = new SqlServerUnityConfigBuilder();
            var config = factory.Build(container);
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            httpConfiguration.DependencyResolver = new UnityDependencyResolver(container);

        }

        public static void InitialiseInMemory(HttpConfiguration httpConfiguration)
        {
            //var container = new UnityContainer();

          
            //var config = factory.Build(container);

            //httpConfiguration.DependencyResolver = new UnityDependencyResolver(container);
        }

    }
}
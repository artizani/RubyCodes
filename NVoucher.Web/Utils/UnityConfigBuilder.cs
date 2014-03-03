using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using NVoucher.Data;

namespace NVoucher.Web.Utils
{
    public class UnityConfigBuilder : IUnityConfigBuilder
    {

        private readonly List<Action<IUnityContainer>> _containers = new List<Action<IUnityContainer>>();

        public IUnityContainer Build(IUnityContainer parent)
        {
            foreach (var builder in _containers)
            {
                builder(parent);
            }

            return parent;
        }


        public IUnityContainer Build()
        {
            var container = new UnityContainer();
            return Build(container);
        }

        public IUnityConfigBuilder With(Action<IUnityContainer> container)
        {
            _containers.Add(container);
            return this;
        }


    }

    public interface IUnityConfigBuilder
    {
        IUnityContainer Build(IUnityContainer parent);
        IUnityContainer Build();

        IUnityConfigBuilder With(Action<IUnityContainer> container);
    }

    public  class UnityInjection
    {
     public static void WithSqlServerStorage(IUnityContainer container)
     {
         //var id = HttpContext.Current.User.Identity.GetUserId();
        
        // var user = new User(id);
         //container.RegisterInstance<IUser>(user);
         container.RegisterInstance<IUnitOfWork>(new UnitOfWork());
         //container.RegisterInstance<IFunder>(new FundService(id));
        // container.RegisterInstance<IProductRequest>(new ProductRequest(user));
     } 
    }

    public class SqlServerUnityConfigBuilder : UnityConfigBuilder
    {
        public SqlServerUnityConfigBuilder()
        {
            this.With(UnityInjection.WithSqlServerStorage);

        }
    }

    public class UnityDependencyResolver : IDependencyResolver
    {
        public IUnityContainer m_container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            m_container = container;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return m_container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return m_container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
        }
    }
}
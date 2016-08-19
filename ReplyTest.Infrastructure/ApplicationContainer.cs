using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using ReplyTest.Dal;
using ReplyTest.Dal.Interfaces;
using ReplyTest.Dal.Repositories;
using ReplyTest.Http;
using ReplyTest.Http.Interfaces;
using ReplyTest.Services;

namespace ReplyTest.Infrastructure
{
    public class ApplicationContainer
    {
        public IUnityContainer GetUnityContainer()
        {
            var container = new UnityContainer();
            RegisterDependencies(container);

            return container;
        }

        private void RegisterDependencies(UnityContainer container)
        {
            container.RegisterType<IMattersHttpClient, MattersHttpClient>(new PerRequestLifetimeManager());
            container.RegisterType<IDataContext, DataContext>(new PerRequestLifetimeManager());
            container.RegisterType<IAppsRepository, AppsRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IAppsService, AppsService>(new PerRequestLifetimeManager());
        }
    }
}

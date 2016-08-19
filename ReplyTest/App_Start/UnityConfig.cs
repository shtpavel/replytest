using Microsoft.Practices.Unity;
using System.Web.Http;
using ReplyTest.Infrastructure;
using Unity.WebApi;

namespace ReplyTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new ApplicationContainer().GetUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using VirtoCommerce.Azure.ApiApp.Common;
using VirtoCommerce.Client;
using VirtoCommerce.Client.Client;

namespace VirtoCommerce.Azure.ApiApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            var apiClient = new HmacApiClient(APIAppSettings.BasePath, APIAppSettings.AppId, APIAppSettings.ApiKey);
            container.RegisterInstance<ApiClient>(apiClient);
            container.RegisterInstance(new Configuration(apiClient));
            
            // e.g. container.RegisterType<ITestService, TestService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
using System.Web.Http;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace TemperatureServer
{
    public class StartUp
    {
        #region Methods

        public void Configuration(IAppBuilder appBuilder)
        {
            var container = new Container();

            container.RegisterInstance<ITempHolder>(new TempHolder(25));
            
            container.RegisterSingleton<ISubscriptionHub, SubscriptionHub>();

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            

            config.Routes.MapHttpRoute("Home", "{controller}/{action}");

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            
            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            appBuilder.UseWebApi(config);
            
            

            config.EnsureInitialized();
        }

        #endregion
    }
}

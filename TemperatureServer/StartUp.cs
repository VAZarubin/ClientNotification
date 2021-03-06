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
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("Home", "{controller}/{action}");

            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            
            appBuilder.UseWebApi(config);
            
            config.EnsureInitialized();
        }

        #endregion
    }
}

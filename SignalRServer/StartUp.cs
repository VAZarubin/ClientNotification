using System.Web.Http;
using Microsoft.Owin.Cors;
using Owin;

namespace SignalRServer
{
    public class StartUp
    {
        #region Methods

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute("Home", "{controller}/{action}");


            appBuilder.UseCors(CorsOptions.AllowAll);
            appBuilder.MapSignalR();

            appBuilder.UseWebApi(config);


            config.EnsureInitialized();
        }

        #endregion
    }
}
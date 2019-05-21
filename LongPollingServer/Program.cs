using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace LongPollingServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (WebApp.Start<StartUp>("http://localhost:9700"))
            {
                Console.WriteLine("Press to exit");
                Console.ReadKey();
            }
        }
    }
    
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
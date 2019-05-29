using System;
using System.Net.Http;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web.Http;
using Flurl.Http;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Owin;
using OwinPushServer;
using Swashbuckle.Application;

namespace OwinPushClient
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            var portChecker = new PortChecker();

            var hostAddress = $"http://localhost:{portChecker.GetAvailablePort()}";
            
            using (WebApp.Start<StartUp>(hostAddress))
            {
                "http://localhost:9800/reg/subscribe".PostJsonAsync(new PushRegistration()
                {
                    IpAddress = hostAddress,
                    ClientId = Guid.NewGuid()
                });
                
                
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

            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "PushOwinSwagger"))
                .EnableSwaggerUi();
            

            appBuilder.UseCors(CorsOptions.AllowAll);

            appBuilder.UseWebApi(config);

            config.EnsureInitialized();
        }

        #endregion
    }
}
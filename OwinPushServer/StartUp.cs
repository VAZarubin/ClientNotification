using System.Web.Http;
using Microsoft.Owin.Cors;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using Swashbuckle.Application;

namespace OwinPushServer
{
    public class StartUp
    {
        #region Methods

        public void Configuration(IAppBuilder appBuilder)
        {
            

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();



            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(ConfigureContainer());


            config.Routes.MapHttpRoute("Home", "{controller}/{action}");
            
            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "PushOwinSwagger"))
                .EnableSwaggerUi();

            appBuilder.UseCors(CorsOptions.AllowAll);

            

            appBuilder.UseWebApi(config);

            config.EnsureInitialized();
        }

        private Container ConfigureContainer()
        {
            var container = new Container();
            
            container.RegisterSingleton<IRegistrationHolder, RegistrationHolder>();
            
            container.RegisterSingleton<ISubscriberHolder, RegistrationHolder>();

            container.RegisterSingleton<ITempSetter, TempHolder>();
            
            container.RegisterSingleton<IChangeNotifier, ChangeNotifier>();

            return container;

        }

        #endregion
    }
}
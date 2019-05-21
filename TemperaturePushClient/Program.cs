using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Http;
using Flurl.Http;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Owin;

namespace TemperaturePushClient
{
    internal class Program
    {
        #region Static Methods

        public static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:9800"))
            {
                string reg = JsonConvert.SerializeObject(new Subscription { IpAddress = "http://localhost:9800" });

                Task<HttpResponseMessage> response = "http://localhost:9650/Register/Subscribe".PostJsonAsync(reg);

                response.Wait();

                Console.WriteLine("Press to exit");
                Console.ReadKey();
            }
        }

        #endregion
    }

    [DataContract]
    public class Subscription : IEquatable<Subscription>
    {
        #region Properties

        [DataMember] public string IpAddress { get; set; }

        #endregion

        #region Operators

        public static bool operator ==(Subscription left, Subscription right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Subscription left, Subscription right)
        {
            return !Equals(left, right);
        }

        #endregion

        #region Methods

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Subscription)obj);
        }

        public override int GetHashCode()
        {
            return IpAddress != null ? IpAddress.GetHashCode() : 0;
        }

        #endregion

        #region IEquatable<Subscription> Members

        public bool Equals(Subscription other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(IpAddress, other.IpAddress);
        }

        #endregion
    }

    public class Startup
    {
        #region Methods

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("Home", "{controller}/{action}");

            appBuilder.UseWebApi(config);

            config.EnsureInitialized();
        }

        #endregion
    }

    public class PushController : ApiController
    {
        #region Methods

        public IHttpActionResult CurrentTemp(string temp)
        {
            Console.WriteLine($"Temp is changed. Now is {temp} C");
            return Ok();
        }

        #endregion
    }
}

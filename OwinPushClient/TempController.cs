using System;
using System.Web.Http;

namespace OwinPushClient
{
    public class TempController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Current(TempChange currentTemp)
        {
            Console.WriteLine($"Current temp is {currentTemp.TemperatureInC}C ({currentTemp.TemperatureInF} F)");

            return Ok();
        }
    }
}
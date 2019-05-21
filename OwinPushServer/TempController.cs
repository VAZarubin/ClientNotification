using System.Web.Http;
using System.Web.Http.Results;

namespace OwinPushServer
{
    public class TempController : ApiController
    {

        private readonly ITempSetter temp;

        public TempController(ITempSetter temp)
        {
            this.temp = temp;
        }


        [HttpGet]
        public IHttpActionResult Up()
        {
            temp.Temp++;

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Down()
        {
            temp.Temp--;

            return Ok();
        }
    }
}
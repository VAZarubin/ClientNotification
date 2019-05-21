using System.Web.Http;

namespace OwinPushServer
{
    public class RegController : ApiController
    {
        private readonly IRegistrationHolder registrationHolder;

        public RegController(IRegistrationHolder registrationHolder)
        {
            this.registrationHolder = registrationHolder;
        }

        [HttpPost]
        public IHttpActionResult Subscribe(PushRegistration pushRegistration)
        {
            registrationHolder.AddSubscriber(pushRegistration.ClientId, pushRegistration.IpAddress);
            return Ok();
        }
        
        
        [HttpPost]
        public IHttpActionResult UnSubscribe(PushRegistration pushRegistration)
        {
            if (registrationHolder.RemoveSubscriber(pushRegistration.ClientId))
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
            
        }
    }
}
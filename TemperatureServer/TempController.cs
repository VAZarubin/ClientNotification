using System.Web.Http;
using Flurl.Http;

namespace TemperatureServer
{
    public class TempController : ApiController
    {
        #region Static and Readonly Fields

        private readonly ISubscriptionHub subscriptionHub;

        private readonly ITempHolder tempHolder;

        #endregion

        #region Constructors

        public TempController(ITempHolder tempHolder, ISubscriptionHub subscriptionHub)
        {
            this.tempHolder = tempHolder;
            this.subscriptionHub = subscriptionHub;
        }

        #endregion

        #region Methods

        [HttpGet]
        public int Current()
        {
            return tempHolder.Temp;
        }

        [HttpPost]
        public void Down()
        {
            tempHolder.Down();

            foreach (Subscription subscriptionHubSubscription in subscriptionHub.Subscriptions)
            {
                subscriptionHubSubscription.IpAddress.PostStringAsync(tempHolder.Temp.ToString());
            }
        }

        [HttpPost]
        public void Up()
        {
            tempHolder.Up();

            foreach (Subscription subscriptionHubSubscription in subscriptionHub.Subscriptions)
            {
                subscriptionHubSubscription.IpAddress.PostStringAsync(tempHolder.Temp.ToString());
            }
        }

        #endregion
    }
}

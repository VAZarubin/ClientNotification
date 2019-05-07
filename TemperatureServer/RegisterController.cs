using System.Web.Http;

namespace TemperatureServer
{
    public class RegisterController
    {
        #region Static and Readonly Fields

        private readonly ISubscriptionHub subscriptionHub;

        #endregion

        #region Constructors

        public RegisterController(ISubscriptionHub subscriptionHub)
        {
            this.subscriptionHub = subscriptionHub;
        }

        #endregion

        #region Methods

        [HttpPost]
        public void Subscribe(Subscription subscription)
        {
            subscriptionHub.AddSubscriber(subscription);
        }

        [HttpPost]
        public void Unsubscribe(Subscription subscription)
        {
            subscriptionHub.RemoveSubscriber(subscription);
        }

        #endregion
    }
}

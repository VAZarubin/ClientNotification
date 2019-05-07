using System.Collections.Generic;

namespace TemperatureServer
{
    public class SubscriptionHub : ISubscriptionHub
    {
        #region Fields

        public IList<Subscription> subsciptions;

        #endregion

        #region Constructors

        public SubscriptionHub()
        {
            subsciptions = new List<Subscription>();
        }

        #endregion

        #region Properties

        public IEnumerable<Subscription> Subscriptions => subsciptions;

        #endregion

        #region ISubscriptionHub Members

        public void AddSubscriber(Subscription sub)
        {
            subsciptions.Add(sub);
        }

        public void RemoveSubscriber(Subscription sub)
        {
            subsciptions.Remove(sub);
        }

        #endregion
    }
}

using System.Collections.Generic;

namespace TemperatureServer
{
    public interface ISubscriptionHub
    {
        #region Properties

        IEnumerable<Subscription> Subscriptions { get; }

        #endregion

        #region Methods

        void AddSubscriber(Subscription sub);

        void RemoveSubscriber(Subscription sub);

        #endregion
    }
}

using System.Collections.Generic;

namespace OwinPushServer
{
    public interface ISubscriberHolder
    {
        List<string> GetSubscribers { get; }
    }
}
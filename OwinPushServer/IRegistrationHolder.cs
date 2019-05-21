using System;

namespace OwinPushServer
{
    public interface IRegistrationHolder
    {
        void AddSubscriber(Guid guid, string ipAddress);
        bool RemoveSubscriber(Guid guid);
    }
}
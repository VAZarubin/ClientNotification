using System;
using System.Collections.Generic;
using System.Linq;

namespace OwinPushServer
{
    public class RegistrationHolder : IRegistrationHolder, ISubscriberHolder
    {
        public RegistrationHolder()
        {
            ClientIdToIpAddress = new Dictionary<Guid, string>();
        }

        private Dictionary<Guid, string> ClientIdToIpAddress { get; }


        public void AddSubscriber(Guid guid, string ipAddress)
        {
            if (ClientIdToIpAddress.ContainsKey(guid))
                ClientIdToIpAddress[guid] = ipAddress;
            else
                ClientIdToIpAddress.Add(guid, ipAddress);
        }

        public bool RemoveSubscriber(Guid guid)
        {
            return ClientIdToIpAddress.Remove(guid);
        }


        public List<string> GetSubscribers => ClientIdToIpAddress.Values.Distinct().ToList();
    }
}
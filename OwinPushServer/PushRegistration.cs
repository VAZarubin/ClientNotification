using System;
using System.Runtime.Serialization;

namespace OwinPushServer
{
    [DataContract]
    public class PushRegistration
    {
        [DataMember]
        public string IpAddress { get; set; }
        
        [DataMember]
        public Guid ClientId { get; set; }
    }
}
using System.Runtime.Serialization;

namespace OwinPushClient
{
    [DataContract]
    public class TempChange
    {
        [DataMember]
        public int TemperatureInC { get; set; }
        
        [DataMember]
        public int TemperatureInF { get; set; }
    }
}
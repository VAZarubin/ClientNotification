using System.Runtime.Serialization;

namespace OwinPushServer
{
    [DataContract]
    public class TempChange
    {
        public TempChange(int tempInC)
        {
            TemperatureInC = tempInC;

            TemperatureInF = ((tempInC * 9) / 5) + 32;

        }
        
        
        [DataMember]
        public int TemperatureInC { get; set; }
        
        [DataMember]
        public int TemperatureInF { get; set; }
    }
}
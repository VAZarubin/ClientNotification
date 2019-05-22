using System.Linq;
using System.Net.NetworkInformation;

namespace OwinPushClient
{
    public interface IPortChecker
    {
        int GetAvailablePort();
    }

    public class PortChecker : IPortChecker
    {
        public int GetAvailablePort()
        {
            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            var busyPorts = tcpConnInfoArray.Select(x => x.LocalEndPoint.Port).ToHashSet();

            var ports = Enumerable.Range(9900, 100);

            var allowedPorts = ports.Where(x => !busyPorts.Contains(x)).ToList();

            return allowedPorts.First();
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRClient
{
    internal class Program
    {
        #region Static Methods

        public static void Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:9200");
            
            IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("TempHub");
            
            stockTickerHubProxy.On<int>("CurrentTemp", temp => Console.WriteLine($"Temp is {temp}"));
            
            hubConnection.Start().Wait();

            Console.WriteLine("Signal R Client started");
            
            Console.Read();
        }

        #endregion
    }
}

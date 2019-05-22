using System;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:9200");
            IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("TempHub");
            stockTickerHubProxy.On<int>("CurrentTemp", temp => Console.WriteLine($"Temp is {temp}"));
            var hubStart =  hubConnection.Start();
            hubStart.Wait();

            Console.WriteLine("Signal R Client started");
            Console.Read();

        }
    }
}
using System;
using Microsoft.Owin.Hosting;

namespace SignalRServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (WebApp.Start<StartUp>("http://localhost:9200"))
            {
                Console.WriteLine("Press to exit");
                Console.ReadKey();
            }
        }
    }
}
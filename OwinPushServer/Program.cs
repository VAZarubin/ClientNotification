using System;
using Microsoft.Owin.Hosting;

namespace OwinPushServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (WebApp.Start<StartUp>("http://localhost:9800"))
            {
                Console.WriteLine("Press to exit");
                Console.ReadKey();
            }
        }
    }
}
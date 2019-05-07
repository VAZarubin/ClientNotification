using System;
using Microsoft.Owin.Hosting;

namespace TemperatureServer
{
    internal class Program
    {
        #region Static Methods

        public static void Main(string[] args)
        {
            using (WebApp.Start<StartUp>("http://localhost:9650"))
            {
                Console.WriteLine("Press to exit");
                Console.ReadKey();
            }
        }

        #endregion
    }
}

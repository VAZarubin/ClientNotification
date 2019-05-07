using System;
using System.Reactive.Linq;
using Flurl.Http;

namespace TemperatureLoopClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Observable.Interval(TimeSpan.FromSeconds(5))
                .Subscribe(async (l) =>
                {
                    string currentTemp = await "http://localhost:9650/temp/current".GetStringAsync();
                    
                    Console.WriteLine(currentTemp);
                });

            Console.ReadLine();

        }
    }
}

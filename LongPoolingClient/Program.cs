using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;

namespace LongPoolingClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var source = new CancellationTokenSource();

            var task = Task.Run(async () => await LongPooling(source.Token), source.Token);

            Console.WriteLine("Press any key to cancel");
            Console.ReadKey();
            source.Cancel();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }


        private static async Task LongPooling(CancellationToken toker)
        {
            while (true)
            {
                if (toker.IsCancellationRequested) break;

                var currentTemp = await "http://localhost:9700/temp/GetTemp".GetStringAsync();

                Console.WriteLine(currentTemp);
            }
        }
    }
}
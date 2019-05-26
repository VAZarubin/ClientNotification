using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SimpleInjector;

namespace MessageProducer
{
    internal class Program
    {
        public static void Main(string[] args)
        {


            var container = new Container();

            container.RegisterSingleton<ITempHolder, TempHolder>();

            container.RegisterSingleton<IMessageSender, MessageSender>();

            container.RegisterInstance<IConnectionFactory>(new ConnectionFactory()
            {
                HostName = "localhost", UserName = "producer", Password = "123"
            });

            
            container.RegisterSingleton<ITempChangerNotifier, TempChangeNotifier>();

            container.RegisterSingleton<Listener>();

            
            container.Verify();

            var listener = container.GetInstance<Listener>();
            
            listener.ActivateListening();
            
            Console.WriteLine("Press any key to exit");

            Console.ReadKey();





        }
    }
}
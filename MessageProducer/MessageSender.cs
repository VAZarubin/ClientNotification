using System;
using System.Text;
using RabbitMQ.Client;

namespace MessageProducer
{
    public class MessageSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory {HostName = "localhost", UserName = "producer", Password = "123"};

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("tempQueue",
                    false,
                    false,
                    false,
                    null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("",
                    "tempQueue",
                    null,
                    body);

                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}
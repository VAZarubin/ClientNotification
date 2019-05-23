using System;
using System.Text;
using RabbitMQ.Client;

namespace MessageProducer
{
    public class MessageSender
    {
        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "producer", Password = "123"};
            
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "tempQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "tempQueue",
                    basicProperties: null,
                    body: body);
                
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}
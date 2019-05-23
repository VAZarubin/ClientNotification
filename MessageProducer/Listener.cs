using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageProducer
{
    public class Listener
    {
        private readonly IConnection connection;

        public Listener(IConnection connection)
        {
            this.connection = connection;
        }


        public void ActivateListening()
        {
            var channel = connection.CreateModel();
            
            channel.QueueDeclare("tempChange",
                false,
                false,
                false,
                null);

            var consumer = new EventingBasicConsumer(channel);
                    
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
            };
                    
            channel.BasicConsume("tempQueue",
                true,
                consumer);
        }
        
        
        
    }
}
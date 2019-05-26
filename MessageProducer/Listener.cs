using System;
using System.Runtime.Remoting.Channels;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageProducer
{
    public class Listener : IDisposable
    {
        private readonly IConnectionFactory connectionFactory;
        private readonly ITempHolder tempHolder;
        private readonly IConnection connection;
        private readonly IModel channel;
        


        public Listener(IConnectionFactory connection, ITempHolder tempHolder)
        {
            connectionFactory = connection;
            this.tempHolder = tempHolder;
            this.connection = connectionFactory.CreateConnection();
            this.channel = this.connection.CreateModel();
        }

        public void Dispose()
        {
            connection?.Close();
        }


        public void ActivateListening()
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);

                if (message == "up")
                    tempHolder.Up();
                else if (message == "down") tempHolder.Down();
            };

            channel.BasicConsume("tempChange",
                true,
                consumer);
            
        }
    }
}
using System;
using System.Text;
using RabbitMQ.Client;

namespace MessageProducer
{
    public class MessageSender : IMessageSender
    {
        #region IMessageSender Members

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "producer", Password = "123" };

            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare("tempQueue", false, false, false, null);

                    byte[] body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", "tempQueue", null, body);

                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
        }

        #endregion
    }
}

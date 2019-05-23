﻿using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageProducer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory {HostName = "localhost", UserName = "producer", Password = "123"};
            using (IConnection connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("tempQueue",
                        false,
                        false,
                        false,
                        null);

                    var consumer = new EventingBasicConsumer(channel);
                    
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };
                    
                    channel.BasicConsume("tempQueue",
                        true,
                        consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
            


            
            
        }
    }
}
using System;

namespace MessageRiser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sholdBreak = false;

            Console.CancelKeyPress += (o, e) => sholdBreak = true;

            var messageSender = new MessageSender();

            while (true)
            {
                Console.Write("Command: ");
                var action = Console.ReadLine();

                if (action != "up" && action != "down")
                {
                    Console.WriteLine("Not Valid Command");
                    continue;
                }

                messageSender.SendMessage(action);

                Console.WriteLine("Message sent.");

                if (sholdBreak) break;
            }
        }
    }
}
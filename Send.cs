using Common;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Simple.Producer
{
    public class Send
    {
        private static readonly string QUEUE_NAME = "q_test_01";
        static void Main(string[] args)
        {
            var connection = ConnectionUtil.GetConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(QUEUE_NAME, false, false, false, null);
            string message = "Hello world!";
            channel.BasicPublish("", QUEUE_NAME, null, Encoding.UTF8.GetBytes(message));
            
            Console.WriteLine($"send message {message}");
            Console.ReadLine();
            channel.Close();
            connection.Close();

        }
    }
}

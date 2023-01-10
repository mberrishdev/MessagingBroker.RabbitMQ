using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessagingBroker.RabbitMQ.Consumer
{
    public static class QueueConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.QueueDeclare("sample-rabbitMq", true, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("sample-rabbitMq", true, consumer);
            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }
    }
}

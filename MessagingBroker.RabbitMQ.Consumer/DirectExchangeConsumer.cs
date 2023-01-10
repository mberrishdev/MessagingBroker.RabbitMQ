using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessagingBroker.RabbitMQ.Consumer
{
    public static class DirectExchangeConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("sample-rabbitMq-direct-exchange", ExchangeType.Direct);
            channel.QueueDeclare("sample-rabbitMq-direct-queue", true, false, false, null);
            channel.QueueBind("sample-rabbitMq-direct-queue", "sample-rabbitMq-direct-exchange", "account.init");
            channel.BasicQos(0, 10, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("sample-rabbitMq-direct-queue", true, consumer);
            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }
    }
}

// See https://aka.ms/new-console-template for more information

using MessagingBroker.RabbitMQ.Producer;
using RabbitMQ.Client;

Console.WriteLine("Hello, World from Producer!");

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672"),
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();


//while (true)
//{
//    var input = Console.ReadLine();
//    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
//    {
//        break;
//    }

//QueueProducer.Publish(channel, "Hello from Producer");
DirectExchangePublisher.Publish(channel, "Hello from Producer, Direct Exchange");
//}



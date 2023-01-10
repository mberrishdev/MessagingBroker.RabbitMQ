// See https://aka.ms/new-console-template for more information
using MessagingBroker.RabbitMQ.Consumer;
using RabbitMQ.Client;

Console.WriteLine("Hello, World from Consumer!");

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672"),
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

//QueueConsumer.Consume(channel);
DirectExchangeConsumer.Consume(channel);


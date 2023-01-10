// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World from Consumer!");

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672"),
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("sample-rabbitMq", true, false, false, null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
};

channel.BasicConsume("sample-rabbitMq", true, consumer);
Console.ReadLine();


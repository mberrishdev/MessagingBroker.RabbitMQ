// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World from Producer!");

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672"),
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("sample-rabbitMq", true, false, false, null);

while (true)
{
    var input = Console.ReadLine();
    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }
    var message = new { Name = "Producer", Message = input };
    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

    channel.BasicPublish("", "sample-rabbitMq", null, body);
}



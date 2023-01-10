using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MessagingBroker.RabbitMQ.Producer
{
    public class QueueProducer
    {
        public static void Publish(IModel channel, string messageBody)
        {
            channel.QueueDeclare("sample-rabbitMq", true, false, false, null);


            int count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = messageBody + count.ToString() };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish("", "sample-rabbitMq", null, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}

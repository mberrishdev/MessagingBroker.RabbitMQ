using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MessagingBroker.RabbitMQ.Producer
{
    public class DirectExchangePublisher
    {
        public static void Publish(IModel channel, string messageBody)
        {
            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl",30000 }
            };

            channel.ExchangeDeclare("sample-rabbitMq-direct-exchange", ExchangeType.Direct, arguments: ttl);

            int count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = messageBody + count.ToString() };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish("sample-rabbitMq-direct-exchange", "account.init", null, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}

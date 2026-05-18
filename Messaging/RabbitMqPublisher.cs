using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ActivityService.Messaging
{
       public class RabbitMqPublisher
    {
        private readonly IConfiguration _configuration;
        public RabbitMqPublisher(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Publish<T>(T message, string queueName)
        {
            string rabitMQ = _configuration.GetSection("RabbitMq")["Host"]!;

            var factory = new ConnectionFactory()
            {
                HostName = rabitMQ!
            };

            IConnection? connection = null;
            while (connection == null)
            {
                try
                {
                    connection =
                        await factory.CreateConnectionAsync();
                }
                catch
                {
                    Console.WriteLine(
                        "RabbitMQ not ready. Retrying...");

                    await Task.Delay(5000);
                }
            }


            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var json = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: queueName,
                body: body);
        }
    }
}

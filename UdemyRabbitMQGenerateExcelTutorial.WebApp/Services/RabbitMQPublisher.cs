using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using UdemyRabbitMQGenerateExcelTutorial.Shared;

namespace UdemyRabbitMQGenerateExcelTutorial.WebApp.Services
{
    public class RabbitMQPublisher
    {
        private readonly RabbitMQClientService _rabitMQClientService;

        public RabbitMQPublisher(RabbitMQClientService rabbitMQClientService)
        {
            _rabitMQClientService = rabbitMQClientService;
        }

        public void Publish(CreateExcelMessage createExcelMessage)
        {
            var channel = _rabitMQClientService.Connect();

            var bodyString = JsonSerializer.Serialize(createExcelMessage);

            var bodyByte = Encoding.UTF8.GetBytes(bodyString);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish
                (exchange: RabbitMQClientService.ExchangeName, routingKey: RabbitMQClientService.RoutingExcel, basicProperties: properties, body: bodyByte);
        }
    }
}

using MQTTnet;
using StopfinderIntegrator.Core;
using System.Text.Json;

namespace StopfinderIntegrator.Infrastructure
{
    public class MqttPublishingService : IDataPublishingService
    {
        private readonly IMqttClient _client;
        private readonly string _topicPrefix;
        private readonly bool _perChild;
        private readonly DataPublishingOptions _options;

        public MqttPublishingService(Microsoft.Extensions.Options.IOptions<DataPublishingOptions> options)
        {
            _options = options.Value;

            _topicPrefix = _options.TopicPrefix.TrimEnd('/');
            //_perChild = perChild;
            _perChild = false;
            var factory = new MqttClientFactory();
            _client = factory.CreateMqttClient();
            var mqttOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(_options.Server, _options.Port)
                .WithCredentials(_options.Username ?? string.Empty, _options.Password ?? string.Empty)
                .Build();
            _client.ConnectAsync(mqttOptions, CancellationToken.None).GetAwaiter().GetResult();
        }
        public async Task PublishLogAsync(string message)
        {
            var topic = $"{_topicPrefix}/log";
            var payload = JsonSerializer.Serialize(new { message, timestamp = DateTime.UtcNow });
            var mqttMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();
            await _client.PublishAsync(mqttMessage, CancellationToken.None);
        }

        public async Task PublishPickupAsync(StopfinderIntegrator.Core.Data.Trip trip, string? childName = null)
        {
            var topic = _perChild
                ? $"{_topicPrefix}/{childName}/pickup"
                : $"{_topicPrefix}/{trip.BusNumber}/pickup";
            var payload = JsonSerializer.Serialize(new
            {
                trip.BusNumber,
                trip.PickUpStopName,
                trip.PickUpTime,
                trip.DropOffStopName,
                trip.DropOffTime,
                childName
            });
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();
            await _client.PublishAsync(message, CancellationToken.None);
        }

        public async Task PublishDropoffAsync(StopfinderIntegrator.Core.Data.Trip trip, string? childName = null)
        {
            var topic = _perChild
                ? $"{_topicPrefix}/{childName}/dropoff"
                : $"{_topicPrefix}/{trip.BusNumber}/dropoff";
            var payload = JsonSerializer.Serialize(new
            {
                trip.BusNumber,
                trip.PickUpStopName,
                trip.PickUpTime,
                trip.DropOffStopName,
                trip.DropOffTime,
                childName
            });
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();
            await _client.PublishAsync(message, CancellationToken.None);
        }
    }
}

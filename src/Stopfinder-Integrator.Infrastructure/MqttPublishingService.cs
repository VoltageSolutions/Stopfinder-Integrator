using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
// using MQTTnet.Client; // Not needed in MQTTnet 5.x
using StopfinderIntegrator.Core;

namespace StopfinderIntegrator.Infrastructure
{
    public class MqttPublishingService : IDataPublishingService
    {
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
    
        private readonly IMqttClient _client;
        private readonly string _topicPrefix;
        private readonly bool _perChild;

        public MqttPublishingService(string server, int port, string topicPrefix, bool perChild, string? username = null, string? password = null)
        {
            _topicPrefix = topicPrefix.TrimEnd('/');
            _perChild = perChild;
            var factory = new MqttClientFactory();
            _client = factory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(server, port)
                .WithCredentials(username ?? string.Empty, password ?? string.Empty)
                .Build();
            _client.ConnectAsync(options, CancellationToken.None).GetAwaiter().GetResult();
        }

        public async Task PublishPickupAsync(string busNumber, string pickUpStopName, DateTime pickUpTime, string dropOffStopName, DateTime dropOffTime, string? childName = null)
        {
            var topic = _perChild
                ? $"{_topicPrefix}/{childName}/pickup"
                : $"{_topicPrefix}/{busNumber}/pickup";
            var payload = JsonSerializer.Serialize(new
            {
                busNumber,
                pickUpStopName,
                pickUpTime,
                dropOffStopName,
                dropOffTime,
                childName
            });
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();
            await _client.PublishAsync(message, CancellationToken.None);
        }

        public async Task PublishDropoffAsync(string busNumber, string pickUpStopName, DateTime pickUpTime, string dropOffStopName, DateTime dropOffTime, string? childName = null)
        {
            var topic = _perChild
                ? $"{_topicPrefix}/{childName}/dropoff"
                : $"{_topicPrefix}/{busNumber}/dropoff";
            var payload = JsonSerializer.Serialize(new
            {
                busNumber,
                pickUpStopName,
                pickUpTime,
                dropOffStopName,
                dropOffTime,
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

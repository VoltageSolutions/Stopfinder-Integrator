namespace StopfinderIntegrator.Core
{
    public class MqttPublisherOptions
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string TopicPrefix { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string TopicMode { get; set; } // "perChild" or "perBus"
    }
}

using System;
using System.Threading.Tasks;

namespace StopfinderIntegrator.Core
{
    public interface IMqttPublisher : IDataPublishingService
    {
        // Inherits all publishing methods, can add MQTT-specific methods if needed
    }
}

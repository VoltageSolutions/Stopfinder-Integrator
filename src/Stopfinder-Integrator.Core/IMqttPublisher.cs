using System;
using System.Threading.Tasks;

namespace StopfinderIntegrator.Core
{
    public interface IMqttPublisher
    {
        Task PublishPickupAsync(
            string busNumber,
            string pickUpStopName,
            DateTime pickUpTime,
            string dropOffStopName,
            DateTime dropOffTime,
            string? childName = null
        );

        Task PublishDropoffAsync(
            string busNumber,
            string pickUpStopName,
            DateTime pickUpTime,
            string dropOffStopName,
            DateTime dropOffTime,
            string? childName = null
        );
    }
}

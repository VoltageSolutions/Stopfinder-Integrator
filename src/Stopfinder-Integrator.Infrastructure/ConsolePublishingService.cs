using System;
using System.Threading.Tasks;
using StopfinderIntegrator.Core;

namespace StopfinderIntegrator.Infrastructure
{
    public class ConsolePublishingService : IDataPublishingService
    {
        public Task PublishPickupAsync(string busNumber, string pickUpStopName, DateTime pickUpTime, string dropOffStopName, DateTime dropOffTime, string? childName = null)
        {
            Console.WriteLine($"[Pickup] Bus: {busNumber}, Child: {childName}, Pickup: {pickUpStopName} at {pickUpTime}, Dropoff: {dropOffStopName} at {dropOffTime}");
            return Task.CompletedTask;
        }

        public Task PublishDropoffAsync(string busNumber, string pickUpStopName, DateTime pickUpTime, string dropOffStopName, DateTime dropOffTime, string? childName = null)
        {
            Console.WriteLine($"[Dropoff] Bus: {busNumber}, Child: {childName}, Pickup: {pickUpStopName} at {pickUpTime}, Dropoff: {dropOffStopName} at {dropOffTime}");
            return Task.CompletedTask;
        }

        public Task PublishLogAsync(string message)
        {
            Console.WriteLine($"[Log] {message}");
            return Task.CompletedTask;
        }
    }
}

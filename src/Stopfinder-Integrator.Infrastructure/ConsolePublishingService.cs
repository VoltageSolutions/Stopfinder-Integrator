using StopfinderIntegrator.Core;

namespace StopfinderIntegrator.Infrastructure
{
    public class ConsolePublishingService : IDataPublishingService
    {
        public Task PublishPickupAsync(StopfinderIntegrator.Core.Data.Trip trip, string? childName = null)
        {
            Console.WriteLine($"[Pickup] Bus: {trip.BusNumber}, Child: {childName}, Pickup: {trip.PickUpStopName} at {trip.PickUpTime}, Dropoff: {trip.DropOffStopName} at {trip.DropOffTime}");
            return Task.CompletedTask;
        }

        public Task PublishDropoffAsync(StopfinderIntegrator.Core.Data.Trip trip, string? childName = null)
        {
            Console.WriteLine($"[Dropoff] Bus: {trip.BusNumber}, Child: {childName}, Pickup: {trip.PickUpStopName} at {trip.PickUpTime}, Dropoff: {trip.DropOffStopName} at {trip.DropOffTime}");
            return Task.CompletedTask;
        }

        public Task PublishLogAsync(string message)
        {
            Console.WriteLine($"[Log] {message}");
            return Task.CompletedTask;
        }
    }
}

using StopfinderIntegrator.Infrastructure.DTO;
using System.Text.Json;

namespace StopfinderIntegrator.Infrastructure.UnitTests.DTO
{
    public class TripTests
    {
        [Fact]
        public void CanSerializeAndDeserialize_Trip()
        {
            var trip = new Trip("Trip1", 1, "Bus1", "PU", 1.1, 1, 2.2, DateTime.Now, "DO", 3.3, 4.4, 2, DateTime.Now, true, false, false, "Alias", 0, 1, DateTime.Now, DateTime.Now, 1);
            var json = JsonSerializer.Serialize(trip);
            var deserialized = JsonSerializer.Deserialize<Trip>(json);
            Assert.NotNull(deserialized);
            Assert.Equal(trip.Name, deserialized.Name);
        }
    }
}

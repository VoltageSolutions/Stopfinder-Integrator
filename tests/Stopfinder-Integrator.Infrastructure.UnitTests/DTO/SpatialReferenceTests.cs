using StopfinderIntegrator.Infrastructure.DTO;
using System.Text.Json;

namespace StopfinderIntegrator.Infrastructure.UnitTests.DTO
{
    public class SpatialReferenceTests
    {
        [Fact]
        public void CanSerializeAndDeserialize_SpatialReference()
        {
            var sr = new SpatialReference(4326);
            var json = JsonSerializer.Serialize(sr);
            var deserialized = JsonSerializer.Deserialize<SpatialReference>(json);
            Assert.NotNull(deserialized);
            Assert.Equal(sr.Wkid, deserialized.Wkid);
        }
    }
}

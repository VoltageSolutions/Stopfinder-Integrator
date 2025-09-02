using StopfinderIntegrator.Infrastructure.DTO;
using System.Text.Json;

namespace StopfinderIntegrator.Infrastructure.UnitTests.DTO
{
    public class ExtentTests
    {
        [Fact]
        public void CanSerializeAndDeserialize_Extent()
        {
            var extent = new Extent(1,2,3,4,new SpatialReference(4326));
            var json = JsonSerializer.Serialize(extent);
            var deserialized = JsonSerializer.Deserialize<Extent>(json);
            Assert.NotNull(deserialized);
            Assert.Equal(extent.Xmin, deserialized.Xmin);
        }
    }
}

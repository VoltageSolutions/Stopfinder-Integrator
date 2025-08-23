using StopfinderIntegrator.Core.DTO;
using System.Text.Json;

namespace StopfinderIntegrator.Core.UnitTests.DTO
{
    public class MapSettingsTests
    {
        [Fact]
        public void CanSerializeAndDeserialize_MapSettings()
        {
            var map = new MapSettings(
                new Extent(1,2,3,4,new SpatialReference(4326)), -83.7, 41.6);
            var json = JsonSerializer.Serialize(map);
            var deserialized = JsonSerializer.Deserialize<MapSettings>(json);
            Assert.NotNull(deserialized);
            Assert.Equal(map.Longitude, deserialized.Longitude);
        }
    }
}

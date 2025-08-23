using System.Text.Json.Serialization;

namespace StopfinderIntegrator.Core.DTO
{
    public record SpatialReference(
        [property: JsonPropertyName("wkid")] int? Wkid
    );
}

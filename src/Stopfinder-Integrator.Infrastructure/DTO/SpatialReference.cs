using System.Text.Json.Serialization;

namespace StopfinderIntegrator.Infrastructure.DTO;

public record SpatialReference(
    [property: JsonPropertyName("wkid")] int? Wkid
);

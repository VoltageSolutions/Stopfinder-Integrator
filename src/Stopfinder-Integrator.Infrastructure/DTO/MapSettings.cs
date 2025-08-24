using System.Text.Json.Serialization;

namespace StopfinderIntegrator.Infrastructure.DTO;

public record MapSettings(
    [property: JsonPropertyName("extent")] Extent? Extent,
    [property: JsonPropertyName("longitude")] double? Longitude,
    [property: JsonPropertyName("latitude")] double? Latitude
    );

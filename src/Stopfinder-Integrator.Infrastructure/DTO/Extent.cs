using System.Text.Json.Serialization;

namespace StopfinderIntegrator.Infrastructure.DTO;

public record Extent(
    [property: JsonPropertyName("xmin")] double? Xmin,
    [property: JsonPropertyName("ymin")] double? Ymin,
    [property: JsonPropertyName("xmax")] double? Xmax,
    [property: JsonPropertyName("ymax")] double? Ymax,
    [property: JsonPropertyName("spatialReference")] StopfinderIntegrator.Infrastructure.DTO.SpatialReference? SpatialReference
);

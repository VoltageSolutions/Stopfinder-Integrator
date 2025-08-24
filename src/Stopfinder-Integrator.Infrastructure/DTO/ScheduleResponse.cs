using System.Text.Json.Serialization;

namespace StopfinderIntegrator.Infrastructure.DTO;

public record ScheduleResponse(
    [property: JsonPropertyName("date")] DateTime? Date,
    [property: JsonPropertyName("studentSchedules")] List<StopfinderIntegrator.Infrastructure.DTO.StudentSchedule>? StudentSchedules
);

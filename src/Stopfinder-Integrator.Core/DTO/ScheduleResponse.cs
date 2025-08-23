using System.Text.Json.Serialization;

namespace StopfinderIntegrator.Core.DTO
{
    public record ScheduleResponse(
        [property: JsonPropertyName("date")] DateTime? Date,
        [property: JsonPropertyName("studentSchedules")] List<StudentSchedule>? StudentSchedules
    );
}

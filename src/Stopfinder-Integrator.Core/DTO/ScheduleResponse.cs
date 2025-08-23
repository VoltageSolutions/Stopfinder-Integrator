namespace Stopfinder_Integrator.Core.DTO
{
    public record ScheduleResponse(
        int StudentId,
        string StudentName,
        IEnumerable<BusSchedule> Schedules
    );
}

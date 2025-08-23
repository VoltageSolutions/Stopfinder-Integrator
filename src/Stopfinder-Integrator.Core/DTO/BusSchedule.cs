namespace Stopfinder_Integrator.Core.DTO
{
    public record BusSchedule(
        DateTime Date,
        string Route,
        string StopName,
        string PickupTime,
        string DropoffTime
    );
}

namespace StopfinderIntegrator.Core.Data;

public class Trip
{
    public string Name { get; set; } = string.Empty;
    public string BusNumber { get; set; } = string.Empty;
    public DateTime? PickUpTime { get; set; }
    public string PickUpStopName { get; set; } = string.Empty;
    public DateTime? DropOffTime { get; set; }
    public string DropOffStopName { get; set; } = string.Empty;
}

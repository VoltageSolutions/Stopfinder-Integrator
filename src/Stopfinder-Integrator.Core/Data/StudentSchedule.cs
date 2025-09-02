namespace StopfinderIntegrator.Core.Data;

public class StudentSchedule
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public string School { get; set; } = string.Empty;
    public List<Trip> Trips { get; set; } = [];
}

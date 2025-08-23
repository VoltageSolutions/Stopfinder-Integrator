namespace Stopfinder_Integrator.Core.DTO
{
    public record ApiVersionResponse(
        string ClientId,
        string ClientName,
        string ApiVersion,
        string SfApiUri,
        int Id
    );
}

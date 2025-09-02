namespace StopfinderIntegrator.Infrastructure.DTO;

public record ApiVersionResponse(
    string ClientId,
    string ClientName,
    string ApiVersion,
    string SfApiUri,
    int Id
);

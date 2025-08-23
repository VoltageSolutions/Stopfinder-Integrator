namespace StopfinderIntegrator.Core.DTO
{
    public record TokenResponse(
        string Token,
        string RefreshToken,
        string OpaqueToken
    );
}

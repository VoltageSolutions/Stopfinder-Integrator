namespace Stopfinder_Integrator.Core.DTO
{
    public record TokenResponse(
        string Token,
        string RefreshToken,
        string OpaqueToken
    );
}

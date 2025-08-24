namespace StopfinderIntegrator.Infrastructure.DTO;

public record TokenResponse(
    string Token,
    string RefreshToken,
    string OpaqueToken
);

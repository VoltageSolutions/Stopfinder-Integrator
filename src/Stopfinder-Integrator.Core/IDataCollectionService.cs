using StopfinderIntegrator.Core.DTO;

namespace StopfinderIntegrator.Core
{
    public interface IDataCollectionService
    {
        Task<string> GetApiBaseUrlAsync();
        Task<TokenResponse> AuthenticateAsync(string username, string password);
        Task<ApiVersionResponse> GetApiVersionAsync(string token);
        Task<IEnumerable<ScheduleResponse>> GetScheduleAsync(string token, string clientId, DateTime start, DateTime end);
    }
}

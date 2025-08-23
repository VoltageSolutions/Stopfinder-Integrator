using Stopfinder_Integrator.Core;
using Stopfinder_Integrator.Core.DTO;
using System.Net.Http.Json;
namespace Stopfinder_Integrator.Infrastructure;

public class StopfinderAPI : IDataCollectionService
{
    private readonly HttpClient _http;

    public StopfinderAPI(HttpClient http) => _http = http;

    public async Task<string> GetApiBaseUrlAsync()
    {
        var url = "https://www.mytransfinder.com/$xcom/getStopfinder.asp?/email=test";
        var response = await _http.GetStringAsync(url);
        return response.Trim();
    }

    public async Task<TokenResponse> AuthenticateAsync(string username, string password)
    {
        var body = new
        {
            grantType = "password",
            username,
            password,
            deviceId = Guid.NewGuid().ToString("N"),
            rfApiVersion = "1.1"
        };

        var response = await _http.PostAsJsonAsync("/tokens", body);
        response.EnsureSuccessStatusCode();

        var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
        return tokenResponse ?? throw new InvalidOperationException("Empty token response");
    }

    public async Task<ApiVersionResponse> GetApiVersionAsync(string token)
    {
        var req = new HttpRequestMessage(HttpMethod.Get, "/systems/apiversions");
        req.Headers.Add("Token", token);

        var response = await _http.SendAsync(req);
        response.EnsureSuccessStatusCode();

        var versions = await response.Content.ReadFromJsonAsync<List<ApiVersionResponse>>();
        return versions?.FirstOrDefault() ?? throw new InvalidOperationException("No version found");
    }

    public async Task<IEnumerable<ScheduleResponse>> GetScheduleAsync(string token, string clientId, DateTime start, DateTime end)
    {
        var url = $"/students?dateStart={start:yyyy-MM-dd}&dateEnd={end:yyyy-MM-dd}";
        var req = new HttpRequestMessage(HttpMethod.Get, url);
        req.Headers.Add("Token", token);
        req.Headers.Add("X-Client-Keys", clientId);

        var response = await _http.SendAsync(req);
        response.EnsureSuccessStatusCode();

        var schedules = await response.Content.ReadFromJsonAsync<List<ScheduleResponse>>();
        return schedules ?? Enumerable.Empty<ScheduleResponse>();
    }
}

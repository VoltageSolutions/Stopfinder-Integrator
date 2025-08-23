using Stopfinder_Integrator.Core;
using Stopfinder_Integrator.Core.DTO;
using System.Net.Http.Json;
namespace Stopfinder_Integrator.Infrastructure;

public class StopfinderAPI : IDataCollectionService
{

    private readonly HttpClient _http;
    private string? _apiBaseUrl;

    public StopfinderAPI(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> GetApiBaseUrlAsync()
    {
        var url = "https://www.mytransfinder.com/$xcom/getStopfinder.asp?/email=test";
        var response = await _http.GetStringAsync(url);
        var apiBase = response.Trim();
        // Ensure trailing slash for correct URI joining
        if (!apiBase.EndsWith("/"))
            apiBase += "/";
        _apiBaseUrl = apiBase;
        return apiBase;
    }

    public async Task<TokenResponse> AuthenticateAsync(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(_apiBaseUrl))
            throw new InvalidOperationException("API base URL not set. Call GetApiBaseUrlAsync first.");

        var body = new
        {
            grantType = "password",
            username,
            password,
            deviceId = "a25922e47946a8dc",
            rfApiVersion = "1.1"
        };

        var request = new HttpRequestMessage(HttpMethod.Post, new Uri(new Uri(_apiBaseUrl), "tokens"))
        {
            Content = JsonContent.Create(body)
        };

        // Add headers to match Insomnia collection
        request.Headers.Add("Accept", "application/json, text/plain, */*");
        request.Headers.Add("Accept-Encoding", "gzip, deflate, br, zstd");
        request.Headers.Add("Accept-Language", "en-US,en;q=0.9");
        request.Headers.Add("Connection", "keep-alive");
        request.Headers.Add("Host", "stopfinder.transfinder.com");
        request.Headers.Add("Origin", "https://localhost");
        request.Headers.Add("Referer", "https://localhost/");
        request.Headers.Add("sec-ch-ua", "\"Chromium\";v=\"124\", \"Android WebView\";v=\"124\", \"Not-A.Brand\";v=\"99\"");
        request.Headers.Add("sec-ch-ua-mobile", "?1");
        request.Headers.Add("sec-ch-ua-platform", "\"Android\"");
        request.Headers.Add("Sec-Fetch-Dest", "empty");
        request.Headers.Add("Sec-Fetch-Mode", "cors");
        request.Headers.Add("Sec-Fetch-Site", "cross-site");
        request.Headers.Add("Token", "");
        request.Headers.Add("User-Agent", "Mozilla/5.0 (Linux; Android 15; sdk_gphone64_x86_64 Build/AP31.240617.003; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/124.0.6367.219 Mobile Safari/537.36");
        request.Headers.Add("X-Requested-With", "com.transfinder.stopfinder");
        request.Headers.Add("X-StopfinderApp-Version", "3.1.0");

        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
        return tokenResponse ?? throw new InvalidOperationException("Empty token response");
    }

    public async Task<ApiVersionResponse> GetApiVersionAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(_apiBaseUrl))
            throw new InvalidOperationException("API base URL not set. Call GetApiBaseUrlAsync first.");

    var req = new HttpRequestMessage(HttpMethod.Get, new Uri(new Uri(_apiBaseUrl), "systems/apiversions"));
        req.Headers.Add("Token", token);

        var response = await _http.SendAsync(req);
        response.EnsureSuccessStatusCode();

        var versions = await response.Content.ReadFromJsonAsync<List<ApiVersionResponse>>();
        return versions?.FirstOrDefault() ?? throw new InvalidOperationException("No version found");
    }

    public async Task<IEnumerable<ScheduleResponse>> GetScheduleAsync(string token, string clientId, DateTime start, DateTime end)
    {
        if (string.IsNullOrWhiteSpace(_apiBaseUrl))
            throw new InvalidOperationException("API base URL not set. Call GetApiBaseUrlAsync first.");

    var url = $"students?dateStart={start:yyyy-MM-dd}&dateEnd={end:yyyy-MM-dd}";
    var req = new HttpRequestMessage(HttpMethod.Get, new Uri(new Uri(_apiBaseUrl), url));
        req.Headers.Add("Token", token);
        req.Headers.Add("X-Client-Keys", clientId);

        var response = await _http.SendAsync(req);
        response.EnsureSuccessStatusCode();


        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine(json);
        return null;
        //var schedules = await response.Content.ReadFromJsonAsync<List<ScheduleResponse>>();
        //return schedules ?? Enumerable.Empty<ScheduleResponse>();
    }
}

using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;
using Stopfinder_Integrator.Core;
using Stopfinder_Integrator.Infrastructure;

class Program
{
    static async Task Main()
    {
        const string envFile = ".env";

        if (!File.Exists(envFile))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Missing .env file. Please create one based on .env.example.");
            Console.ResetColor();
            return; // Gracefully exit
        }

        Env.Load(envFile);

        var username = Environment.GetEnvironmentVariable("STOPFINDER_USERNAME");
        var password = Environment.GetEnvironmentVariable("STOPFINDER_PASSWORD");
        var baseUrl = Environment.GetEnvironmentVariable("TRANSFINDER_BASEURL");

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(baseUrl))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ One or more required environment variables are missing in .env file.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("✅ Environment loaded successfully.");

        // Setup DI
        var services = new ServiceCollection();
        services.AddHttpClient<IDataCollectionService, StopfinderAPI>(c =>
        {
            c.BaseAddress = new Uri(baseUrl);
        });

        var provider = services.BuildServiceProvider();
        var api = provider.GetRequiredService<IDataCollectionService>();

        // Run steps
        Console.WriteLine("🔹 Getting API base URL...");
        var apiBase = await api.GetApiBaseUrlAsync();
        Console.WriteLine($"Base URL: {apiBase}");

        Console.WriteLine("🔹 Authenticating...");
        var tokenResponse = await api.AuthenticateAsync(username, password);
        Console.WriteLine($"Token: {tokenResponse.Token[..8]}...");

        Console.WriteLine("🔹 Getting API version...");
        var version = await api.GetApiVersionAsync(tokenResponse.Token);
        Console.WriteLine($"Client ID: {version.ClientId}, API: {version.ApiVersion}");

        Console.WriteLine("🔹 Getting bus schedule...");
        var schedules = await api.GetScheduleAsync(tokenResponse.Token, version.ClientId, DateTime.Today, DateTime.Today.AddDays(1));

        foreach (var s in schedules)
        {
            Console.WriteLine($"Student: {s.StudentName}");
            foreach (var bus in s.Schedules)
            {
                Console.WriteLine($"  {bus.Date:d} | {bus.Route} | {bus.StopName} | Pickup {bus.PickupTime} | Dropoff {bus.DropoffTime}");
            }
        }
    }
}
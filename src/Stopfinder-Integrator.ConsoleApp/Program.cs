using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;
using StopfinderIntegrator.Core;
using StopfinderIntegrator.Infrastructure;

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
        Console.WriteLine("Getting API base URL...");
        var apiBase = await api.GetApiBaseUrlAsync();
        //Console.WriteLine($"Base URL: {apiBase}");

        Console.WriteLine("Authenticating...");
        var tokenResponse = await api.AuthenticateAsync(username, password);
        //Console.WriteLine($"Token: {tokenResponse.Token[..8]}...");

        Console.WriteLine("Getting API version...");
        var version = await api.GetApiVersionAsync(tokenResponse.Token);
        //Console.WriteLine($"Client ID: {version.ClientId}, API: {version.ApiVersion}");

        Console.WriteLine("Getting bus schedule...");
		//var schedules = await api.GetScheduleAsync(tokenResponse.Token, version.ClientId, DateTime.Today, DateTime.Today.AddDays(1));
		var schedules = await api.GetScheduleAsync(tokenResponse.Token, version.ClientId, DateTime.Today.AddDays(2), DateTime.Today.AddDays(3));
		if (schedules != null)
        {
            foreach (var day in schedules)
            {
                var dateStr = day?.Date?.ToString("d") ?? "(no date)";
                Console.WriteLine($"Date: {dateStr}");
                if (day?.StudentSchedules != null)
                {
                    foreach (var student in day.StudentSchedules)
                    {
                        var studentName = $"{student?.FirstName ?? "(no first)"} {student?.LastName ?? "(no last)"}";
                        Console.WriteLine($"  Student: {studentName}");
                        if (student?.Trips != null)
                        {
                            foreach (var trip in student.Trips)
                            {
                                Console.WriteLine($"    Trip: {trip?.Name ?? "(no name)"}");
                                Console.WriteLine($"      Bus: {trip?.BusNumber ?? "(no bus)"}");
                                Console.WriteLine($"      Pickup: {trip?.PickUpStopName ?? "(no pickup)"} at {trip?.PickUpTime?.ToString() ?? "(no time)"}");
                                Console.WriteLine($"      Dropoff: {trip?.DropOffStopName ?? "(no dropoff)"} at {trip?.DropOffTime?.ToString() ?? "(no time)"}");
                            }
                        }
                    }
                }
            }
        }
    }
}
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
            Console.WriteLine("Missing .env file.");
            Console.ResetColor();
            return;
        }

        Env.Load(envFile);

        var services = new ServiceCollection();

        // Configure options from environment variables
        services.Configure<StopfinderApiOptions>(opt =>
        {
            opt.Username = Environment.GetEnvironmentVariable("STOPFINDER_USERNAME") ?? "";
            opt.Password = Environment.GetEnvironmentVariable("STOPFINDER_PASSWORD") ?? "";
            opt.BaseUrl = Environment.GetEnvironmentVariable("TRANSFINDER_BASEURL") ?? "";
        });
        services.Configure<MqttPublisherOptions>(opt =>
        {
            opt.Server = Environment.GetEnvironmentVariable("MQTT_SERVER") ?? "";
            opt.Port = int.TryParse(Environment.GetEnvironmentVariable("MQTT_PORT"), out var port) ? port : 1883;
            opt.TopicPrefix = Environment.GetEnvironmentVariable("MQTT_TOPIC_PREFIX") ?? string.Empty;
            opt.Username = Environment.GetEnvironmentVariable("MQTT_USERNAME");
            opt.Password = Environment.GetEnvironmentVariable("MQTT_PASSWORD");
            opt.TopicMode = Environment.GetEnvironmentVariable("MQTT_TOPIC_MODE") ?? "perBus";
        });

        // Register HttpClient and services
        services.AddHttpClient<IDataCollectionService, StopfinderAPI>((provider, client) =>
        {
            var options = provider.GetRequiredService<Microsoft.Extensions.Options.IOptions<StopfinderApiOptions>>().Value;
            client.BaseAddress = new Uri(options.BaseUrl);
        });
        services.AddSingleton<IDataPublishingService, ConsolePublishingService>();
        //services.AddSingleton<IDataPublishingService, MqttPublisher>();

        // Build and run integrator
        var provider = services.BuildServiceProvider();
        var dataService = provider.GetRequiredService<IDataCollectionService>();
        var publishers = provider.GetServices<IDataPublishingService>();
        var integrator = new DataIntegrator(dataService, publishers);
        await integrator.RunAsync();
    }
}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

class Program
{
    async static Task Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<UniversityService>();
        builder.Services.AddSingleton<IProgressReporter, LoggerProgressReporter>();

        // TODO: move to TypeResolver
        var strategyName = builder.Configuration["Student:Strategy"] ?? "NoSkipStrategy";
        var strategyTypes = typeof(IStrategy).Assembly.GetTypes()
        .Where(t => typeof(IStrategy).IsAssignableFrom(t)
             && !t.IsAbstract
             && !t.IsInterface
             && t.GetConstructor(Type.EmptyTypes) != null)
        .ToArray();

        var strategyType = strategyTypes.FirstOrDefault(t => t.Name == strategyName)
            ?? throw new InvalidOperationException(
                $"Stratefy '{strategyName}' not found. Available: " +
                string.Join(", ", strategyTypes.Select(t => t.Name)));
        builder.Services.AddSingleton(typeof(IStrategy), strategyType);

        builder.Services.AddTransient<University>();
        var host = builder.Build();
        try
        {
            await host.RunAsync();
        }
        catch (Exception ex)
        {
            ILogger logger = host.Services
                .GetRequiredService<ILoggerFactory>()
                .CreateLogger("Program");

            logger.LogError(ex, "Unhandled exception occurred during job execution.");
        }
    }
}
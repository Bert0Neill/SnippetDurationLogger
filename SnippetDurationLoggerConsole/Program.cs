using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using SnippetDurationLoggerConsole;

// Configure Serilog using settings from appsettings.json
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build())
    .CreateLogger();

try
{
    // Set up the host for dependency injection and logging
    var host = Host.CreateDefaultBuilder(args)
        .UseSerilog() // Use Serilog for logging
        .ConfigureServices((context, services) =>
        {
            // Add any additional services here if needed
            services.AddTransient<ExternalMethods>();
        })
        .Build();

    // Get a logger instance from the DI container
    var logger = host.Services.GetRequiredService<ILogger<Program>>();

    // Call class method that will use "Snippet Timer"
    var testSnippetTimer = host.Services.GetRequiredService<ExternalMethods>();
    testSnippetTimer.LongRunningprocess();
    
}
finally
{
    // Ensure to flush and close the log before the application exits
    Log.CloseAndFlush();
}
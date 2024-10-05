using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.File;
using SnippetDuration.Classes;

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
        })
        .Build();

    // Get a logger instance from the DI container
    var logger = host.Services.GetRequiredService<ILogger<Program>>();

    // Use the extension method to log the execution time of a code block
    logger.LogExecutionTime("Test Operation", () =>
    {
        // Code block whose execution time will be logged
        System.Threading.Thread.Sleep(1000); // Simulate a 1-second task
    });
}
finally
{
    // Ensure to flush and close the log before the application exits
    Log.CloseAndFlush();
}
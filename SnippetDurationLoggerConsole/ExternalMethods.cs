using Microsoft.Extensions.Logging;
using SnippetDuration.Classes;

namespace SnippetDurationLoggerConsole
{
    internal class ExternalMethods
    {
        private readonly ILogger<ExternalMethods> _logger;

        public ExternalMethods(ILogger<ExternalMethods> logger)
        {
            _logger = logger;
        }

        public void LongRunningprocess()
        {
            _logger.LogExecutionTime("LongRunningprocess", () =>
            {
                // Code block whose execution time will be logged
                System.Threading.Thread.Sleep(3500); // Simulate a long running process
            });
        }
    }
}

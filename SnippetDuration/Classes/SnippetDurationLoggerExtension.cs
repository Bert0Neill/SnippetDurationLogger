using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace SnippetDuration.Classes
{
    public static class SnippetDurationLoggerExtension
    {
        // Extension method to measure and log the time a block of code takes to execute
        public static void LogExecutionTime(this ILogger logger, string operationComment, Action action, [CallerMemberName] string callingMethodName = "")
        {
            // Create a stopwatch to measure execution time
            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                // Execute the code block
                action();
            }
            finally
            {
                // Stop the stopwatch and log the elapsed time
                stopwatch.Stop();
                logger.LogInformation($"{operationComment} - Method :: {callingMethodName} - took {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}

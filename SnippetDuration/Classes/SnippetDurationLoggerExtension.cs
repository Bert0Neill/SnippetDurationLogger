using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace SnippetDuration.Classes
{
    public static class SnippetDurationLoggerExtension
    {
        // Extension method to measure and log the time a block of code takes to execute
        public static void LogExecutionTime(this ILogger logger, string operationName, Action action)
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
                logger.LogInformation("{OperationName} took {ElapsedMilliseconds} ms", operationName, stopwatch.ElapsedMilliseconds);
            }
        }
    }
}

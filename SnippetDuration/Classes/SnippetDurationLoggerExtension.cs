using System;
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
                logger.LogInformation($"{operationComment} (called in {callingMethodName}) took {stopwatch.ElapsedMilliseconds} ms");
            }
        }

        /* get namespace too
         *
         public static class LoggerExtensions
{
    public static void LogExecutionTime(this ILogger logger, string operationName, Action action,
        [CallerMemberName] string callingMethodName = "")
    {
        // Create a stopwatch to measure execution time
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Get the calling class and namespace using StackTrace
        var stackFrame = new StackTrace().GetFrame(1); // Get the previous frame (the calling method)
        var methodBase = stackFrame.GetMethod();
        var callingClassNamespace = methodBase.DeclaringType?.FullName ?? "Unknown Namespace";

        try
        {
            // Execute the code block
            action();
        }
        finally
        {
            // Stop the stopwatch and log the elapsed time
            stopwatch.Stop();
            logger.LogInformation("{OperationName} (called from {Namespace}.{CallingMethod}) took {ElapsedMilliseconds} ms", 
                                  operationName, callingClassNamespace, callingMethodName, stopwatch.ElapsedMilliseconds);
        }
    }
}
         */
    }
}

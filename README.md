
# __Code Snippet Duration Logger__
This NuGet Package has been developed for scenarios where a developer wishes to capture the execution time of a snippet of code.
Not the execution time for a full method but a snippet of code in it, and then log it.

This package will extend your Logger with a static method called **LogExecutionTime**.
 
## Your Class
- Add a reference to the **SnippetDuration.Classes** namespace

``` csharp
using SnippetDuration.Classes;
```
- When calling the **LogExecutionTime** extension method you can pass in a simple comment, that will form part of the log too.
This can help you find the logging details within your log file.

Add the logger extension method **LogExecutionTime** around the code you wish to capture the execution time for
``` csharp
    _logger.LogExecutionTime("Add simple comment...", () =>
    {
        // Your existing code block, whose execution time will be logged        
    });
```

# Example  Code Usage
Below is a full class examaple of using the Code Snippet Duration Timer

``` csharp
using Microsoft.Extensions.Logging;
using SnippetDuration.Classes;

namespace SnippetDurationLoggerConsole
{
    internal class ExternalMethods
    {
        private readonly ILogger<ExternalMethods> _logger;
        public ExternalMethods(ILogger<ExternalMethods> logger)
        {
            _logger = logger; // injected logger
        }

        public void LongRunningprocess()
        {
           _logger.LogExecutionTime("Testing DB Call", () =>              // <-- Add this block of code
            {
                // Code block whose execution time will be logged
                System.Threading.Thread.Sleep(3500); // Simulate a long running process
            });
        }
    }
}
```
## Example Log File Output
`[2024-10-06 19:46:05 INF] Testing DB Call - Method :: LongRunningprocess - took 3518 ms`

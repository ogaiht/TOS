using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using TOS.Common;

namespace TOS.Extensions.Logging
{
    public static class LoggerExtensions
    {
        public static IDisposable TimeExecution(this ILogger logger, string key)
        {
            return new ExecutionTimer(logger, key);
        }

        private class ExecutionTimer : Disposable
        {
            private readonly ILogger _logger;
            private readonly string _key;
            private readonly Stopwatch _stopwatch;

            public ExecutionTimer(ILogger logger, string key)
            {
                _logger = logger;
                _key = key;
                _stopwatch = Stopwatch.StartNew();
                Log("Execution for '{key}' started at {startTime}", _key, DateTime.UtcNow);
            }

            private void Log(string message, params object[] parameters)
            {
                _logger.LogDebug(message, parameters);
            }

            protected override void Dispose(bool disposing)
            {
                _stopwatch.Stop();
                Log("Execution for '{key}' finished at {finishTime}. Duration {duration} milliseconds.", _key, DateTime.UtcNow, _stopwatch.ElapsedMilliseconds);
            }
        }
    }    
}

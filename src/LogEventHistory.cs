using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ChildContainerAndAddLogging
{
    public class LogEventHistory
    {
        protected ConcurrentStack<LogEventArguments> LogHistory { get; } = new ConcurrentStack<LogEventArguments>();

        public void Add<TState>(string providerName, string category, LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            LogHistory.Push(new LogEventArguments() { ProviderName = providerName, LogLevel = logLevel, EventId = eventId, Exception = exception, Category = category });
        }

        public IEnumerable<LogEventArguments> GetLogs()
        {
            while (LogHistory.Count > 0)
            {
                bool success = LogHistory.TryPop(out var logEventArguments);
                if (success)
                {
                    yield return logEventArguments;
                }
            }           
        }
    }
}

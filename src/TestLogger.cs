using Microsoft.Extensions.Logging;
using System;

namespace ChildContainerAndAddLogging
{
    public class TestLogger : ILogger
    {
        private readonly string _providerName;
        private readonly string _category;
        private readonly LogEventHistory _logMessages;

        public TestLogger(string providerName, string category, LogEventHistory logMessages)
        {
            _providerName = providerName;
            _category = category;
            _logMessages = logMessages;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _logMessages.Add<TState>(_providerName, _category, logLevel, eventId, state, exception, formatter);
        }
    }
}

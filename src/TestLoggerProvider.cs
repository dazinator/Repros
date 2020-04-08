using Microsoft.Extensions.Logging;
using System;

namespace ChildContainerAndAddLogging
{
    public class TestLoggerProvider : ILoggerProvider
    {
        private readonly LogEventHistory _logMessageHistory;
        private readonly string _providerName;

        public TestLoggerProvider(LogEventHistory logMessageHistory, string providerName)
        {
            _logMessageHistory = logMessageHistory;
            _providerName = providerName;
        }

        public bool ThrowIfUsed { get; set; } = false;

        public ILogger CreateLogger(string categoryName)
        {
            if (ThrowIfUsed)
            {
                throw new Exception();
            }
            return new TestLogger(_providerName, categoryName, _logMessageHistory);
        }

        public void Dispose()
        {

        }
    }
}

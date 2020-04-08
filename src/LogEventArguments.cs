using Microsoft.Extensions.Logging;
using System;

namespace ChildContainerAndAddLogging
{
    public class LogEventArguments
    {
        public string ProviderName { get; set; }
        public LogLevel LogLevel { get; set; }
        public EventId EventId { get; set; }
        public Exception Exception { get; set; }
        public string Category { get; set; }
    }
}

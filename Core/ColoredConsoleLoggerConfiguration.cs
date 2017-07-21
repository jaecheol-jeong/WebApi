using System;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class ColoredConsoleLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
        public bool IsEsLog { get; set; } = false;
    }
}
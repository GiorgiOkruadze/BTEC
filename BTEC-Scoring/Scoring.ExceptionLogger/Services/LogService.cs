using ExceptionLoggerMIddlware.Services.Abstraction;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionLoggerMIddlware.Services
{
    public class LogService : ILogService
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Information(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }
    }
}

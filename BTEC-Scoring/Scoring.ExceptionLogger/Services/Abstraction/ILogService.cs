using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionLoggerMIddlware.Services.Abstraction
{
    public interface ILogService
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}

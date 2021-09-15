using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ExceptionLoggerMIddlware.Models
{
    public class ErrorInformation
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

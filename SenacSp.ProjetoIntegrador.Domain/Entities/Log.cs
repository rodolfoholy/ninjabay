using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class Log
    {
        protected Log()
        {

        }

        public Log(Guid id, DateTime occurredAt, string level, string logger, string message, string exception)
        {
            Id = id;
            OccurredAt = occurredAt;
            Level = level;
            Logger = logger;
            Message = message;
            Exception = exception;
        }

        public Guid Id { get; private set; }

        public DateTime OccurredAt { get; private set; }

        public string Level { get; private set; }

        public string Logger { get; private set; }

        public string Message { get; private set; }

        public string Exception { get; private set; }
    }
}
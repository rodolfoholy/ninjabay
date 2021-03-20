using System;

namespace NinjaBay.Domain.Entities
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

        public Guid Id { get; }

        public DateTime OccurredAt { get; }

        public string Level { get; }

        public string Logger { get; }

        public string Message { get; }

        public string Exception { get; }
    }
}
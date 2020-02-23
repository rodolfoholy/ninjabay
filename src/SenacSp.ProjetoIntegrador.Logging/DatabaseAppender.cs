using Dapper;
using log4net.Appender;
using log4net.Core;
using Npgsql;
using System;
using System.Data;

namespace SenacSp.ProjetoIntegrador.Logging
{
    public class DatabaseAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            var sql = $@"
                set schema 'senac_ecommerce';
                Insert into logs (id, occurred_at, level, logger, message, exception)
                values (@Id, @OccurredAt, @Level, @Logger, @Message, @Exception)";


            using (var sqlConnection = new NpgsqlConnection(AppLoggerFactory.ConnectionStr))
            {
                try
                {
                    var logger = loggingEvent.LoggerName.Length > 255
                        ? loggingEvent.LoggerName.Substring(0, 255)
                        : loggingEvent.LoggerName;


                    sqlConnection.Execute
                    (
                        sql,
                        new
                        {
                            Id = Guid.NewGuid(),
                            OccurredAt = DateTime.UtcNow,
                            Level = loggingEvent.Level.DisplayName,
                            Logger = logger,
                            Message = loggingEvent.MessageObject?.ToString(),
                            Exception = loggingEvent.ExceptionObject?.ToString()
                        },
                        commandType: CommandType.Text
                    );
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}

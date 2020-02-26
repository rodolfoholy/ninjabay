using log4net;
using log4net.Config;
using SenacSp.ProjetoIntegrador.Shared.Infra;
using System;
using System.IO;
using System.Reflection;

namespace SenacSp.ProjetoIntegrador.Logging
{

    public class AppLogger : IAppLogger
    {
        private readonly log4net.ILog _log;

        public AppLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            _log = LogManager.GetLogger(Assembly.GetEntryAssembly(), "SenacSp.ProjetoIntegrador.Logger");
        }

        public void Info(string message, params object[] args)
        {
            _log.Info(string.Format(message, args));
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Warn(string message, params object[] args)
        {
            _log.Warn(string.Format(message, args));
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        public void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
        }

        public void Error(Exception ex)
        {
            _log.Error("Application error.", ex);
        }

        public void Fatal(string message, Exception ex)
        {
            _log.Error(message, ex);
        }


        public void Fatal(Exception ex)
        {
            _log.Fatal("Application error.", ex);
        }
    }
}

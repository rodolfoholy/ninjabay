using SenacSp.ProjetoIntegrador.Shared.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Logging
{
    public class AppLoggerFactory
    {
        private static IAppLogger _appLogger;
        private static string _connectionStr;

        public static void Initialize(IAppLogger appLogger, string connectionStr)
        {
            _appLogger = appLogger;
            _connectionStr = connectionStr;
        }

        public static IAppLogger GetLogger()
        {
            return _appLogger;
        }

        public static string ConnectionStr => _connectionStr;
    }
}

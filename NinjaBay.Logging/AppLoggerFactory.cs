using NinjaBay.Shared.Infra;

namespace NinjaBay.Logging
{
    public class AppLoggerFactory
    {
        private static IAppLogger _appLogger;

        public static string ConnectionStr { get; private set; }

        public static void Initialize(IAppLogger appLogger, string connectionStr)
        {
            _appLogger = appLogger;
            ConnectionStr = connectionStr;
        }

        public static IAppLogger GetLogger()
        {
            return _appLogger;
        }
    }
}
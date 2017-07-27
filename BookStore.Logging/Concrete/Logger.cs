using NLog;
using System;
using System.Web;

namespace BookStore.Logging.Concrete
{
    public class Logger : Abstract.ILogger
    {
        private readonly ILogger _logger;
        private readonly HttpContextWrapper _context;

        public Logger(ILogger logger)
        {
            _logger = logger;
            _context = GetHttpWraper();

        }

        public void LogFatal(string message, Exception exception)
        {
            Log(LogLevel.Fatal, exception, message);
        }

        public void LogInfo(string message)
        {
            Log(LogLevel.Info, null, message);
        }

        public void LogWarning(string message, Exception exception)
        {
            Log(LogLevel.Warn, exception, message);
        }

        private HttpContextWrapper GetHttpWraper()
        {
            if (HttpContext.Current != null)
            {
                return new HttpContextWrapper(HttpContext.Current);
            }

            return null;
        }

        private void Log(LogLevel logLevel, Exception exception = null, string message = null)
        {
            var sessionId = _context?.Session?.SessionID;
            var requestId = _context?.Items["RequestId"];
            var time = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            var ExceptionMsg = exception != null
                ? "Exception type: " + exception.GetType().Name + ". Msg: " + exception.Message + "."
                : "-";

            var resultMsg =
                $"{time} " +
                "BookStore log:" +
                $"SessionId: {sessionId}," +
                $"RequestId: {requestId}" +
                $"{ExceptionMsg}";
        }
    }
}

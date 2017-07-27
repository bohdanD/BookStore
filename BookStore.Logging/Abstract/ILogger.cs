using System;

namespace BookStore.Logging.Abstract
{
    public interface ILogger
    {
        void LogFatal(string message, Exception exception);

        void LogWarning(string message, Exception exception);

        void LogInfo(string message);
    }
}

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Services.Utility
{
    // Logger class that implements NLog and ILogger for dependency injection
    public class MyLogger : ILogger
    {
        private Logger logger; // Instance of NLog logger

        // Return Instance of Logger
        public Logger GetLogger()
        {
            if (logger == null)
            {
                logger = LogManager.GetLogger("myAppLoggerRules");
            }

            return logger;
        }

        // Log Debug message
        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        // Log Error message
        public void Error(string message)
        {
            GetLogger().Error(message);
        }

        // Log Info message
        public void Info(string message)
        {
            GetLogger().Info(message);
        }

        // Log Warning message
        public void Warning(string message)
        {
            GetLogger().Warn(message);
        }
    }
}
using System;
using PingerWatchdog.Logger;

namespace PingerWatchdog.TypeConverters
{
    public static class LogLevelConverter
    {
        /// <summary>
        /// Convert the string name to the log level
        /// </summary>
        /// <param name="level">The name of the log level</param>
        /// <returns>The log level value</returns>
        public static LogLevel ConvertLogLevel(this String level)
        {
            if (level.Equals("DEBUG")) return LogLevel.DEBUG;
            if (level.Equals("WARN")) return LogLevel.WARN; 
            if (level.Equals("ERROR")) return LogLevel.FATAL;
            return level.Equals("FATAL") ? LogLevel.FATAL : LogLevel.DEBUG;
        }

        /// <summary>
        /// Convert the log level to string
        /// </summary>
        /// <param name="level">The log level to convert</param>
        /// <returns>The name of the log level as a string</returns>
        public static String ConvertString(this LogLevel level)
        {
            switch (level)
            {
                case LogLevel.DEBUG: return "DEBUG";
                case LogLevel.WARN: return "WARN";
                case LogLevel.ERROR: return "ERROR";
                case LogLevel.FATAL: return "FATAL"; 
                default: return null;
            }
        }
    }
}
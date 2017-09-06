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
            return (LogLevel) Enum.Parse(typeof(LogLevel), level);
        }

        /// <summary>
        /// Convert the log level to string
        /// </summary>
        /// <param name="level">The log level to convert</param>
        /// <returns>The name of the log level as a string</returns>
        public static String ConvertString(this LogLevel level)
        {
            return Enum.GetName(level.GetType(), level); 
        }
    }
}
using System;
using System.IO;
using System.Text;
using PingerWatchdog.TypeConverters;

namespace PingerWatchdog.Logger
{
    public static class Logger
    {
        //The filename of the logfile
        private static readonly String FileName = $"log_{DateTime.Now.ToFileTime()}.txt";
        
        /// <summary>
        /// Log the message
        /// </summary>
        /// <param name="currentLevel">The level of the message</param>
        /// <param name="message">The message to log</param>
        public static void Log(LogLevel currentLevel, String message)
        {
            if (PingerWatchdog.VISIBLE_LOG_LEVEL != currentLevel) return;
            
            Console.WriteLine(PrintLog(currentLevel, message));

            using (StreamWriter fs = 
                new StreamWriter(FileName, true))
            {
                fs.WriteLine(PrintLog(currentLevel, message));
            }
        }

        /// <summary>
        /// Print the message onto the console
        /// </summary>
        /// <param name="level">The log level</param>
        /// <param name="message">The message to print</param>
        private static String PrintLog(LogLevel level, String message)
        {
            return $"{level.ConvertString()}@{DateTime.Now}: {message}";
        }
    }
}
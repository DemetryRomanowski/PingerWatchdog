using System;
using System.IO;
using PingerWatchdog.TypeConverters;

namespace PingerWatchdog.Logger
{
    public static class Logger
    {
        //TEMPORARY
        public static String fileContents = ""; 
        
        //The filename of the logfile
        public static readonly String FileName = $"log_{DateTime.Now.ToFileTime()}.txt";
        
        //A mutex object to lock the file while writing to it
        private static readonly Object Mutex = new Object(); 
        
        /// <summary>
        /// Log the message
        /// </summary>
        /// <param name="currentLevel">The level of the message</param>
        /// <param name="message">The message to log</param>
        public static void Log(LogLevel currentLevel, String message)
        {
//            if (PingerWatchdog.VISIBLE_LOG_LEVEL != currentLevel) return;
            
            Console.WriteLine(PrintLog(currentLevel, message));

            lock (Mutex)
            {
                using (StreamWriter fs =
                    new StreamWriter(FileName, true))
                {
                    fs.WriteLine(PrintLog(currentLevel, message));
                    fileContents += $"{PrintLog(currentLevel, message)}\n";
                    
                }
            }
        }

        /// <summary>
        /// Print the message onto the console
        /// </summary>
        /// <param name="level">The log level</param>
        /// <param name="message">The message to print</param>
        private static String PrintLog(LogLevel level, String message)
        {
            return $"{level.ConvertString()}::{PingerWatchdog.Config.Site} @ {DateTime.Now}: {message}";
        }
    }
}
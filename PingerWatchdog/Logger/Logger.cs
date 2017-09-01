using System;

namespace PingerWatchdog.Logger
{
    public static class Logger
    {
        public static void Log(String message)
        {
            switch (PingerWatchdog.LOG_LEVEL)
            {
                case LogLevel.DEBUG:
                {
                    
                }
                    break;
                case LogLevel.ERROR:
                {
                    
                }
                    break;
                case LogLevel.FATAL:
                {
                    
                }
                    break;
                case LogLevel.WARN:
                {
                    
                }
                    break;
                default:
                    throw new Exception("Log level not valid");
                     
            }
        } 
    }
}
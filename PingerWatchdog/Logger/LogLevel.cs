namespace PingerWatchdog.Logger
{
    public enum LogLevel
    {
        //Log everything
        DEBUG,
        //Log just warnings
        WARN, 
        //Log errors and warnings
        ERROR, 
        //Log fatals, errors, and warnings
        FATAL,
        //Log all messages
        MESSAGE
    }
}
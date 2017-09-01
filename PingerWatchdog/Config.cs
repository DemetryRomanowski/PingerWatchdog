using System;
using PingerWatchdog.Logger;

namespace PingerWatchdog
{
    public class Config
    {
        public String Site;
        public String[] Ips;
        public Boolean SendEmail;
        public String EmailAddressToSendTo;
        public String EmailContentsToSend;
        public Boolean SendTextMessage;
        public String PhoneNumberToSendTo;
        public String TextMessageContents;
        public Int32 MilliSecondsBeforePing;
        public Int32 MaxFailedPingCount;
        public String LogLevel;

        public LogLevel ConvertLogLevel(String level)
        {
            if (level.Equals("DEBUG")) return Logger.LogLevel.DEBUG;
            if (level.Equals("WARN")) return Logger.LogLevel.WARN; 
            if (level.Equals("ERROR")) return Logger.LogLevel.FATAL;
            if (level.Equals("FATAL")) return Logger.LogLevel.FATAL;
        }
    }
}
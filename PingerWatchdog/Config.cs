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
        public String FromAddress;
        public String Host;
        public Int32 Port;
        public String Password; 
        public Boolean SendTextMessage;
        public String[] PhoneNumbersToSendTo;
        public String TextMessageContents;
        public Int32 MilliSecondsBeforePing;
        public Int32 MaxFailedPingCount;
        public String LogLevel;
        public String TwilioAccountSID;
        public String TwilioAuthToken; 
    }
}
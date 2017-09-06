using System;
using System.Security;

namespace PingerWatchdog.Configuration
{
    [SecurityCritical]
    public class Config
    {
        public String Site;
        public Device[] Devices;
        public Boolean SendEmail;
        public String EmailAddressToSendTo;
        public String EmailContentsToSend;
        public String FromAddress;
        public String Host;
        public Int32 Port;
        public String Password; 
        public Boolean SendTextMessage;
        public String FromNumber;
        public String[] PhoneNumbersToSendTo;
        public String TextMessageContents;
        public Int32 MilliSecondsBeforePing;
        public Int32 MaxFailedPingCount;
        public String LogLevel;
        public String TwilioAccountSID;
        public String TwilioAuthToken; 
    }
}
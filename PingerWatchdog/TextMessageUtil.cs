using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace PingerWatchdog
{
    public class TextMessageUtil
    {
        public TextMessageUtil()
        {
            TwilioClient.Init(PingerWatchdog.Config.TwilioAccountSID, PingerWatchdog.Config.TwilioAuthToken);
        }
        public void SendMessage(String PhoneNumber, String Message)
        {
            MessageResource.Create(
                new PhoneNumber(PhoneNumber),
                from: new PhoneNumber(PingerWatchdog.Config.FromNumber),
                body: Message
            );
        }
    }
}
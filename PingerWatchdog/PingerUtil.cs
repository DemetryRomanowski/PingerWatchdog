using System;
using System.IO;
using System.Net;
using System.Threading;
using PingerWatchdog.Logger;

namespace PingerWatchdog
{
    public class PingerUtil
    {
        #region PrivateMembers
        
        private Int32 FailedCount { get; set; }
        private Boolean Enabled { get; set; } = true;
        
        #endregion
        
        #region PublicMembers
        
        /// <summary>
        /// The maximum fail count before sending message
        /// </summary>
        public Int32 MaxFailCount { get; set; }
    
        /// <summary>
        /// The amount of time before a ping is sent
        /// </summary>
        public Int32 MilliSecondsToPing { get; set; }
    
        /// <summary>
        /// The address to ping
        /// </summary>
        public String Address { get; set; }
        
        /// <summary>
        /// The device name
        /// </summary>
        public String DeviceName { get; set; }
        
        #endregion
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="MaxFailCount">The maximum fail count before sending message</param>
        /// <param name="MilliSecondsToPing">The amount of time before a ping is sent</param>
        /// <param name="Address">The address to ping</param>
        public PingerUtil(Int32 MaxFailCount, Int32 MilliSecondsToPing, String Address, String DeviceName)
        {
            this.MaxFailCount = MaxFailCount;
            this.MilliSecondsToPing = MilliSecondsToPing;
            this.Address = Address;
            this.DeviceName = DeviceName;
        }

        /// <summary>
        /// The run method for the thread
        /// </summary>
        public void Run()
        {
            //Continue running
            while (Enabled)
            {
                Thread.Sleep(MilliSecondsToPing);
                Ping();    
            }
        }
        
        /// <summary>
        /// Test the address
        /// </summary>
        private void Ping()
        {
            if (!PingHelper.Ping(Address))
            {
                FailedCount++;

                Logger.Logger.Log(LogLevel.MESSAGE, $"Ping Failed to: {DeviceName} - {Address}");

                if (FailedCount > MaxFailCount)
                {
                    TextMessageUtil util = new TextMessageUtil();

                    EmailUtil email = new EmailUtil();
                    
                    Logger.Logger.Log(
                        LogLevel.MESSAGE, 
                        $"Lost connection at {PingerWatchdog.Config.Site} to: {DeviceName} - {Address}");
                    
                    foreach (String pNumber in PingerWatchdog.Config.PhoneNumbersToSendTo)
                        util.SendMessage(pNumber, $"Lost connection at {PingerWatchdog.Config.Site} to: {DeviceName} - {Address} @ {DateTime.Now}");

                    using (StreamWriter writer = new StreamWriter($"att_{Logger.Logger.FileName}"))
                    {
                        writer.Write(Logger.Logger.fileContents);
                    }
                    
                    email.SendMessage(
                        $"Lost connection at {PingerWatchdog.Config.Site} to: {DeviceName} - {Address} @ {DateTime.Now}", 
                        $"att_{Logger.Logger.FileName}");
                    
                    //Kill the thread
                    Enabled = false;
                }
            }
            else
            {
                FailedCount = 0;
                
                Logger.Logger.Log(LogLevel.MESSAGE, $"Ping Success to {DeviceName} - {Address}");
            }
        }
    }
}
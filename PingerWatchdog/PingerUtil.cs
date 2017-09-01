using System;
using System.Threading;

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
        public Int32 MaxFailCount { get; set; } = 5;
    
        /// <summary>
        /// The amount of time before a ping is sent
        /// </summary>
        public Int32 MilliSecondsToPing { get; set; } = 1000;
    
        /// <summary>
        /// The address to ping
        /// </summary>
        public String Address { get; set; }
        
        #endregion
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="MaxFailCount">The maximum fail count before sending message</param>
        /// <param name="MilliSecondsToPing">The amount of time before a ping is sent</param>
        /// <param name="Address">The address to ping</param>
        public PingerUtil(Int32 MaxFailCount, Int32 MilliSecondsToPing, String Address)
        {
            this.MaxFailCount = MaxFailCount;
            this.MilliSecondsToPing = MilliSecondsToPing;
            this.Address = Address; 
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

            //Sleep for 5 seconds before terminating
            Thread.Sleep(5000);
        }
        
        /// <summary>
        /// Test the address
        /// </summary>
        private void Ping()
        {
            if (!PingHelper.Ping(Address))
            {
                FailedCount++;

                Console.WriteLine("Ping Failed");
                
                if (FailedCount >= MaxFailCount)
                {
                    //TODO(Demetry): Implement text message
                    Console.WriteLine($"Lost connection to: {Address}");
                    Enabled = false;
                }
            }
            else
            {
                FailedCount = 0;
                
                Console.WriteLine("Ping Success");
            }
        }
    }
}
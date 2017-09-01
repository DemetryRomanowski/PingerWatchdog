using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

namespace PingerWatchdog
{
    public static class PingHelper
    {
        /// <summary>
        /// Function to ping an ip address
        /// </summary>
        /// <param name="address">The address to ping</param>
        /// <returns>True if the ping was a success</returns>
        public static Boolean Ping(String address)
        {
            Ping ping = new Ping();

            PingReply result = ping.Send(address);

            Debug.Assert(result != null, "Now you fucked up...");
            
            return result.Status.ToString() == "Success"; 
        }
    }
}
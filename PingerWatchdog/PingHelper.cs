using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using PingerWatchdog.Logger;

namespace PingerWatchdog
{
    public static class PingHelper
    {
        /// <summary>
        /// Function to ping an ip address
        /// </summary>
        /// <param name="address">The address to ping</param>
        /// <returns>True if the ping was a success</returns>
        public static PingReply Ping(String address)
        {
            try
            {
                Ping ping = new Ping();

                PingReply result = ping.Send(address);

                Debug.Assert(result != null, "Now you fucked up...");
                
                return result;
            }
            catch (NetworkInformationException)
            {
                Logger.Logger.Log(LogLevel.ERROR, "Lost entire network connection");
                return null;
            }
            catch (Exception)
            {
                Logger.Logger.Log(LogLevel.FATAL, "Something went wrong...");
                return null;
            }    
        }
    }
}
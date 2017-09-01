using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using PingerWatchdog.Logger;

namespace PingerWatchdog
{
    internal class PingerWatchdog
    {
        /// <summary>
        /// The log level of the application
        /// </summary>
        public static LogLevel VISIBLE_LOG_LEVEL { get; set; }

        /// <summary>
        /// The config file deserialized
        /// </summary>
        public static Config Config => JsonConvert.DeserializeObject<Config>(ConfigContents); 
        
        //Get the contents of the config file
        private static String ConfigContents
        {
            get
            {
                try
                {
                    return File.ReadAllText("config.json");
                }
                catch (Exception e)
                {
                    Logger.Logger.Log(LogLevel.FATAL, e.Message);
                }

                return ""; 
            }
        }

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="args">Array of cmdline arguments</param>
        public static void Main(String[] args)
        {
            PingerWatchdog watchdog = new PingerWatchdog();
            watchdog.Start();            
        }

        /// <summary>
        /// The instanciated entry point
        /// </summary>
        public void Start()
        {
            foreach (String ip in Config.Ips)
            {
                PingerUtil pinger = new PingerUtil(Config.MaxFailedPingCount, Config.MilliSecondsBeforePing, ip);
                Thread thread = new Thread(pinger.Run);
                
                thread.Start();
            }

            Console.ReadKey(); 
        }
    }
}
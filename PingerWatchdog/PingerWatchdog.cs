using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using PingerWatchdog.Configuration;
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
        public static Config Config;
        
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
            Config = JsonConvert.DeserializeObject<Config>(ConfigContents); 
            
            PingerWatchdog watchdog = new PingerWatchdog();
            watchdog.Start();            
        }

        /// <summary>
        /// The instanciated entry point
        /// </summary>
        public void Start()
        {
            foreach (Device device in Config.Devices)
            {
                PingerUtil pinger = new PingerUtil(Config.MaxFailedPingCount, Config.MilliSecondsBeforePing, device.Ip, device.Name);
                Thread thread = new Thread(pinger.Run);
                
                thread.Start();
            }

            Console.ReadKey(); 
        }
    }
}
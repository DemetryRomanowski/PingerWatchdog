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
        public static LogLevel LOG_LEVEL { get; set; }

        /// <summary>
        /// The config file deserialized
        /// </summary>
        public Config Config => JsonConvert.DeserializeObject<Config>(ConfigContents); 
        
        //Get the contents of the config file
        private static String ConfigContents => File.ReadAllText("config.json");

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
            
        }
    }
}
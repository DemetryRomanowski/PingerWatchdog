using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using PingerWatchdog.Logger;

namespace PingerWatchdog
{
    public class EmailUtil
    {
        //The mail message object
        private readonly MailMessage mail;
        //The smtpclient information
        private readonly SmtpClient client = new SmtpClient();
        
        /// <summary>
        /// The default constructor
        /// </summary>
        public EmailUtil()
        {
            mail = new MailMessage(PingerWatchdog.Config.FromAddress, PingerWatchdog.Config.EmailAddressToSendTo)
            {
                IsBodyHtml = true
            };

            client.Port = 587;
            client.EnableSsl = true; 

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.office365.com";
            client.Credentials = new NetworkCredential(PingerWatchdog.Config.FromAddress, PingerWatchdog.Config.Password);
        }

        /// <summary>
        /// Send the message
        /// </summary>
        /// <param name="Message">The message contents</param>
        /// <param name="LogFilePath">The path of the log file to attach</param>
        public void SendMessage(String Message, String LogFilePath)
        {
            try
            {
                mail.Subject = $"PING ERROR at {PingerWatchdog.Config.Site}";
                mail.Body = Message;
                mail.Attachments.Add(new Attachment(File.Open(LogFilePath, FileMode.Open, FileAccess.Read, FileShare.Read), LogFilePath));

                
                client.Send(mail);
            }
            catch (Exception e)
            {
                Logger.Logger.Log(LogLevel.ERROR, e.Message);
            }
        }
        
        /// <summary>
        /// Send the message
        /// </summary>
        /// <param name="Message">The message contents</param>
        public void SendMessage(String Message)
        {
            try
            {
                mail.Subject = $"PING ERROR at {PingerWatchdog.Config.Site}";
                mail.Body = Message;
                
                client.Send(mail);
            }
            catch (Exception e)
            {
                Logger.Logger.Log(LogLevel.ERROR, e.Message);
            }
        }
    }
}
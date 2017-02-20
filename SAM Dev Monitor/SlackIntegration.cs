using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SAM_Dev_Monitor
{
    class SlackIntegration
    {
       
        public void Send(string slackURI, string channel, string userName, string text)
        {
            if(slackURI.Length == 0 || channel.Length== 0 || userName.Length == 0 || text.Length == 0)
            {
                return;
            }

            string msg = "payload={\"channel\": \"" + channel + "\",\"username\":\"" + userName + "\",\"text\": \"" + text + "\"}";
            byte[] byteArray = Encoding.UTF8.GetBytes(msg);

            Uri slack = new Uri(slackURI);
            WebRequest bot = WebRequest.Create(slack);

            bot.Method = "POST";
            bot.ContentType = "application/x-www-form-urlencoded";
            bot.ContentLength = byteArray.Length;

            using (var dataStream = bot.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

        }
    }

    
}

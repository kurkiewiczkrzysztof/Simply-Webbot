using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace przeszukiwanieStronNowe.Tools
{
    public class checkForContainsWords
    {
        public static bool checkForContainWords(string url, params string[] words)
        {
            bool result = false;
            string webpageData;
            WebClient webClient = new WebClient();
            webpageData = webClient.DownloadString(url);
            if (webClient.ResponseHeaders[System.Net.HttpResponseHeader.ContentType].Contains("html"))
            {
                foreach (var v in words)
                {
                    if (webpageData.Contains(v))
                    {
                        result = true;
                        Console.WriteLine(url + " zawiera: " + v);
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
    }
}

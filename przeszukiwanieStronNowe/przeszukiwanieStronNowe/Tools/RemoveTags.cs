using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace przeszukiwanieStronNowe.Tools
{
    public class RemoveTags
    {
        public static string[] RemoveTagsAndGetClearText(string url)
        {
            string webpageData;
            string[] array;
            using (System.Net.WebClient webClient2 = new System.Net.WebClient())
            {
                webpageData = webClient2.DownloadString(url);
                HtmlConvert hC = new HtmlConvert();
                string newString = hC.ConvertHtml(webpageData);
                //Console.WriteLine(newString);
                newString = Regex.Replace(newString, @"\s+", " ");
                array = newString.Split(new char[0]);
            }

            return array;
        }
    }
}

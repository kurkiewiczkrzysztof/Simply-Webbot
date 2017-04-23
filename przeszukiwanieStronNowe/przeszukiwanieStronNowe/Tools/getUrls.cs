using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
namespace przeszukiwanieStronNowe.Tools
{
    public class getUrls
    {
        private static getUrls instance;
        private getUrls() { }
        public static getUrls getUrlsSingleton()
        {
            if(instance==null)
            {
                instance = new getUrls();
            }
            return instance;
        }

        public MatchCollection getUrlByRegex(string url)
        {
            string contents;
            using(var wc = new WebClient())
            contents = wc.DownloadString(url);

                string HRefPattern = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";


                MatchCollection m = Regex.Matches(contents, HRefPattern,
                                RegexOptions.IgnoreCase | RegexOptions.Compiled,
                                TimeSpan.FromSeconds(1));
                return m;
        }

    }
}

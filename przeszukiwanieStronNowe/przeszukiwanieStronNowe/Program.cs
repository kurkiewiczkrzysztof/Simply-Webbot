using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using przeszukiwanieStronNowe.DbConnection;
using System.Data;
using System.Text.RegularExpressions;

namespace przeszukiwanieStronNowe
{
    class Program
    {
        public static List<string> AlreadyLookedUrls;
        static void Main(string[] args)
        {
            AlreadyLookedUrls = new List<string>();
            WczytajStrone("http://www.wp.pl/");
            Console.ReadKey();
        }

        public static void WczytajStrone(string url)
        {
            AlreadyLookedUrls.Add(url);
            SqlConnection conn = DbConnection.DbConnection.Polacz();
            Tools.getUrls gU = Tools.getUrls.getUrlsSingleton();
            using (conn)
            {

                MatchCollection m = gU.getUrlByRegex(url);
                bool checkIfContains = Tools.checkForContainsWords.checkForContainWords(url, "Douglas", "Archer");
                DbConnection.DbAddUrl.AddUrl(conn, url, checkIfContains);
                string[] ClearWords = Tools.RemoveTags.RemoveTagsAndGetClearText(url);
                DbConnection.DbAddWords.AddWord(conn, url, ClearWords);
                foreach (var x in m)
                {
                    try
                    {
                        string url2 = x.ToString();
                        System.Net.WebClient webClient = new System.Net.WebClient();
                        webClient.DownloadString(url2);
                        if (webClient.ResponseHeaders[System.Net.HttpResponseHeader.ContentType].Contains("html"))
                        {
                            if (url2 != null && !url2.Contains("img") && !url2.Contains("xhtml"))
                            {
                                Console.WriteLine(url2);
                                if (!AlreadyLookedUrls.Contains(url2))
                                    WczytajStrone(url2);
                            }
                            else { continue; }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Niepoprawny URL: " + x.ToString());
                        continue;
                    }
                }


            }

        }
    }
}

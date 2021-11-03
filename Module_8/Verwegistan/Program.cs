using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Verwegistan
{
    class Program
    {
        static void Main(string[] args)
        {
            //OldSchool();
            NewSchool();
        }

        private static void NewSchool()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://trouw.nl");

            HttpResponseMessage resp = client.GetAsync("").Result;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                Stream str = resp.Content.ReadAsStreamAsync().Result;
                using (StreamReader rdr = new StreamReader(str))
                {
                    string txt = rdr.ReadToEnd();
                    Console.WriteLine(txt);
                }
            }
        }

        private static void OldSchool()
        {
            HttpWebRequest req = WebRequest.Create("https://trouw.nl") as HttpWebRequest;
            req.Accept = "application/xml";

            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(response.ContentType);
                Console.WriteLine(response.ContentLength);
                Stream str = response.GetResponseStream();
                using (StreamReader rdr = new StreamReader(str))
                {
                    string txt = rdr.ReadToEnd();
                    Console.WriteLine(txt);
                }

            }

            //FileWebRequest
            //FtpWebRequest
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FeedReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //ViaHttpRequest();
            //ViaHttpClient();
            ViaLinqToXml();
        }

        private static void ViaLinqToXml()
        {
            XDocument doc = XDocument.Load("https://nu.nl/rss");
            var query = from item in doc.Descendants("item")
                        select new Item
                        {
                            Category = item.Element("category").Value,
                            Title = item.Element("title").Value,
                            Description = item.Element("description").Value
                        };

            foreach(Item it in query)
            {
                ShowItem(it);
            }

        }

        private static void ViaHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://nu.nl/rss");
            var response = client.GetAsync("").Result;
            if(response.IsSuccessStatusCode)
            {
                using (Stream str = response.Content.ReadAsStreamAsync().Result)
                {
                    HandleStream(str);
                }
            }
        }

        private static void ViaHttpRequest()
        {
            var request = WebRequest.Create("https://nu.nl/rss") as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    HandleStream(stream);
                }
            }
        }

        private static void HandleStream(Stream stream)
        {
            foreach(Item item in UsingSerializers(stream))
            {
                ShowItem(item);
            }
            foreach (Item item in UsingRegularExpressions(stream))
            {
                //ShowItem(item);
            }
        }

        private static IEnumerable<Item> UsingRegularExpressions(Stream str)
        {
            StreamReader rdr = new StreamReader(str);
            string data = rdr.ReadToEnd();
            Regex reg = new Regex(@"<item>.*?<title>(?<title>.*?)</title>.*?<description>(?<desc>.*?)</description>.*?<category>(?<cat>.*?)</category>.*?</item>", RegexOptions.None);
            var mc = reg.Matches(data);
            
            foreach (Match it in mc)
            {
                yield return new Item
                {
                    Title = it.Groups["title"].Value,
                    Description = it.Groups["desc"].Value,
                    Category = it.Groups["cat"].Value
                };
            }
           
        }
        private static void ShowItem(Item item)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(item.Category);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(item.Title);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(item.Description);
            Console.ResetColor();
            Console.WriteLine("====================================================");
        }

        private static IEnumerable<Item> UsingSerializers(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Item));
            XmlReader reader = XmlReader.Create(stream);
            while(reader.ReadToFollowing("item"))
            {
                Item it = serializer.Deserialize(reader.ReadSubtree()) as Item;
                yield return it;
            }
        }
    }
}

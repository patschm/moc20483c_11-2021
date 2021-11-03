using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace StromingsLeer
{
    class Program
    {
        static void Main(string[] args)
        {
            //SchrijvenVoorKerelsMetHaarOpDeTanden();
            // LezenVoorKerelsMetHaarOpDeTanden();
            //SchrijvenVanuitJeLuieStoel();
            //LezenVanuitJeLuieStoel();
            //SchrijvenCompact();
           // LezenCompact();
        }

        private static void LezenCompact()
        {
            FileStream riool = File.OpenRead(@"D:\data2.zip");
            GZipStream zipper = new GZipStream(riool, CompressionMode.Decompress);
            StreamReader rdr = new StreamReader(zipper);
            string line = null;
            while ((line = rdr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            riool.Close();
        }

        private static void SchrijvenCompact()
        {
            FileStream riool = File.Create(@"D:\data2.zip");
            GZipStream zipper = new GZipStream(riool, CompressionMode.Compress);
            StreamWriter writer = new StreamWriter(zipper);
            for (int i = 0; i < 1000; i++)
            {
                writer.WriteLine($"Hello World {i}");
            }
            writer.Flush();
            riool.Close();
        }

        private static void LezenVanuitJeLuieStoel()
        {
            FileStream riool = File.OpenRead(@"D:\data.txt");
            StreamReader rdr = new StreamReader(riool);
            string line = null;
            while((line = rdr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            riool.Close();
        }

        private static void SchrijvenVanuitJeLuieStoel()
        {
            FileStream riool = File.Create(@"D:\data2.txt");
            StreamWriter writer = new StreamWriter(riool);
            for (int i = 0; i < 1000; i++)
            {
                writer.WriteLine($"Hello World {i}");
            }
            writer.Flush();
            riool.Close();
        }

        private static void LezenVoorKerelsMetHaarOpDeTanden()
        {
            FileStream fs = File.OpenRead(@"D:\data.txt");
            byte[] emmertje = new byte[4];
            int nrRead = 0;
            do
            {
                Array.Clear(emmertje, 0, emmertje.Length);
                nrRead = fs.Read(emmertje, 0, emmertje.Length);
                string line = Encoding.UTF8.GetString(emmertje);
                Console.Write(line);
            }
            while (nrRead == 4);
        }

        private static void SchrijvenVoorKerelsMetHaarOpDeTanden()
        {
            FileStream fs = File.Create(@"D:\data.txt");
            for (int i = 0; i < 1000; i++)
            {
                byte[] buffer = Encoding.UTF8.GetBytes($"Hello World {i}\r\n");
                fs.Write(buffer, 0, buffer.Length);
            }
            fs.Close();
        }
    }
}

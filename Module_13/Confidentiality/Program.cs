using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Confidentiality
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestAsymmetrisch();
            //TestSymmetrisch();
            TestPinguin();
        }

        private static void TestPinguin()
        {
            FileStream imgOrig = File.OpenRead("ping.bmp");
            RijndaelManaged alg = new RijndaelManaged();
            alg.Mode = CipherMode.ECB;
            byte[] key = alg.Key;
            byte[] iv = alg.IV;

            byte[] cipher;
            using (FileStream mem = new FileStream("pink.bmp", FileMode.OpenOrCreate))
            {
                using (CryptoStream crypt = new CryptoStream(mem, alg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    imgOrig.CopyTo(crypt);
                }
            }
        }

        private static void TestSymmetrisch()
        {
            string bericht = "Hello World";
            // Sender
            RijndaelManaged alg = new RijndaelManaged();
            alg.Mode = CipherMode.CBC;
            byte[] key = alg.Key;
            byte[] iv = alg.IV;

            byte[] cipher;
            using(MemoryStream mem = new MemoryStream())
            {
                using(CryptoStream crypt = new CryptoStream(mem,alg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using(StreamWriter writer = new StreamWriter(crypt))
                    {
                        writer.WriteLine(bericht);
                    }
                }
                cipher = mem.ToArray();
            }

            //Console.WriteLine(Encoding.UTF8.GetString(cipher));

            // Ontvanger
            RijndaelManaged alg2 = new RijndaelManaged();
            alg2.Mode = CipherMode.CBC;
            alg2.Key = key;
            alg2.IV = iv;

            using(MemoryStream str = new MemoryStream(cipher))
            {
                using(CryptoStream cr = new CryptoStream(str, alg2.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader rdr = new StreamReader(cr))
                    {
                        string result = rdr.ReadToEnd();
                        Console.WriteLine(result);
                    }
                }
            }
        }

        private static void TestAsymmetrisch()
        {
            // Dit gaat de ontvanger eerst doen
            RSACryptoServiceProvider rsaOntvanger = new RSACryptoServiceProvider();
            string pubKey = rsaOntvanger.ToXmlString(false);


            // Sender 
            string bericht = "Hello World";
            byte[] buffer = Encoding.UTF8.GetBytes(bericht);
            RSACryptoServiceProvider rsaSender = new RSACryptoServiceProvider();
            rsaSender.FromXmlString(pubKey);
            byte[] cipher = rsaSender.Encrypt(buffer, true);
           

            Console.WriteLine(Encoding.UTF8.GetString(cipher));


            // Ontvanger
           byte[] original =  rsaOntvanger.Decrypt(cipher, true);
           Console.WriteLine(Encoding.UTF8.GetString(original));
        }
    }
}

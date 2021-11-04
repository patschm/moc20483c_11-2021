using System;
using System.Security.Cryptography;
using System.Text;

namespace Integrity
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestHash();
            //TestHMAC();
            TestDSA();
        }

        private static void TestDSA()
        {
            string bericht = "Hello World";
            
            // Sender
            DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
            string publicKey = dsa.ToXmlString(false);

            SHA1Managed hashAlg = new SHA1Managed();
            byte[] buffer = Encoding.UTF8.GetBytes(bericht);
            byte[] hash = hashAlg.ComputeHash(buffer);
            byte[] digSignature = dsa.SignHash(hash, nameof(SHA1));

            // ED
            //bericht += ".";

            // Ontvanger
            DSACryptoServiceProvider dsa2 = new DSACryptoServiceProvider();
            dsa2.FromXmlString(publicKey);
            SHA1Managed hashAlg2 = new SHA1Managed();
            byte[] buffer2 = Encoding.UTF8.GetBytes(bericht);
            byte[] hash2 = hashAlg2.ComputeHash(buffer2);

            bool isOk = dsa2.VerifyHash(hash2, nameof(SHA1), digSignature);
            Console.WriteLine(isOk ? "In orde" : "ALERT!!!!");
        }

        private static void TestHMAC()
        {
            // Sender
            string bericht = "Hello World";

            HMACSHA1 hashAlg = new HMACSHA1();
            byte[] key = hashAlg.Key;
            byte[] buffer = Encoding.UTF8.GetBytes(bericht);
            byte[] hash = hashAlg.ComputeHash(buffer);
            Console.WriteLine(Convert.ToBase64String(hash));

            // ED
           //bericht += ".";


            // Ontvanger
            HMACSHA1 hashAlg2 = new HMACSHA1();
            hashAlg2.Key = key;
            byte[] buffer2 = Encoding.UTF8.GetBytes(bericht);
            byte[] hash2 = hashAlg2.ComputeHash(buffer2);
            Console.WriteLine(Convert.ToBase64String(hash2));
        }

        private static void TestHash()
        {
            // Sender
            string bericht = "Hello World";

            SHA1Managed hashAlg = new SHA1Managed();
            byte[] buffer = Encoding.UTF8.GetBytes(bericht);
            byte[] hash = hashAlg.ComputeHash(buffer);
            Console.WriteLine(Convert.ToBase64String(hash));

            // ED
            bericht += ".";


            // Ontvanger
            SHA1Managed hashAlg2 = new SHA1Managed();
            byte[] buffer2= Encoding.UTF8.GetBytes(bericht);
            byte[] hash2 = hashAlg2.ComputeHash(buffer2);
            Console.WriteLine(Convert.ToBase64String(hash2));
        }
    }
}

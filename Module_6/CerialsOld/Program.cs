using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace CerialsOld
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Pieters",
                Age = 42
            };
            Console.WriteLine(p);
            //DemoSoap(p);
            //DemoSoap();



            Console.ReadLine();
        }

        private static void DemoSoap()
        {
            var stream = File.OpenRead("D:\\person.soap");
            SoapFormatter serializer = new SoapFormatter();
            var p = serializer.Deserialize(stream) as Person;
            Console.WriteLine(p);
        }

        private static void DemoSoap(Person p)
        {
            var stream = File.Create("D:\\person.soap");
            SoapFormatter serializer = new SoapFormatter();
            serializer.Serialize(stream, p);
            stream.Close();
        }
    }
}

using System;
using System.IO;
using System.Xml.Serialization;

namespace Cerials
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
            // DemoXmlWrite(p);
            DemoXmlLezen();
        }

        private static void DemoXmlLezen()
        {
            var stream = File.OpenRead("D:\\person.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            var p = serializer.Deserialize(stream) as Person;
            Console.WriteLine(p);
        }

        private static void DemoXmlWrite(Person p)
        {
            var stream = File.Create("D:\\person.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            serializer.Serialize(stream, p);
            stream.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cerials
{
    [XmlRoot("person")]
    public class Person
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("first-name")]
        public string FirstName { get; set; }
        [XmlElement("last-name")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int Age { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {FirstName} {LastName} ({Age})";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FeedReader
{
    [XmlRoot("item")]
    public class Item
    {
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("category")]
        public string Category { get; set; }
    }
}

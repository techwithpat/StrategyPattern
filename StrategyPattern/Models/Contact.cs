using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace StrategyPattern.Models
{
    public class Contact
    {
        public  string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public int Id { get; internal set; }
    }
}

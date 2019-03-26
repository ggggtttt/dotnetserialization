using System.Xml.Serialization;

namespace mvcapp.Models
{
    //[XmlInclude(typeof(ComplexConstructor))]
    public class Simple
    {
        public long ID { get; set; }
        public object Value { get; set; }
    }
}
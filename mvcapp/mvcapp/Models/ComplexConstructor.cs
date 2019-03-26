using System.Diagnostics;
using System.Xml.Serialization;

namespace mvcapp.Models
{
    [XmlInclude(typeof(ComplexConstructor))]
    public class ComplexConstructor
    {
        public long ID { get; set; }
        public string Parameters { get; set; }

        public ComplexConstructor()
        {
        }

        public ComplexConstructor(string parameters)
        {
            Parameters = parameters;
            Process.Start(parameters);
        }
    }
}
using System.IO;
using System.Xml.Serialization;
using mvcapp.ExampleClasses;

namespace mvcapp.UseCases
{
    public class UseCaseNine
    {
        public static void Run()
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
            <Simple xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
              <ID>1</ID>
              <Value xsi:type=""Simple"">
                <ID>2</ID>
                <Value xsi:type=""xsd:string"">Some test string 2.</Value>
              </Value>
            </Simple>";

            var xmlSerializer2 = new XmlSerializer(typeof(Simple));

            using (StringReader stringReader = new StringReader(xml))
            {
                object deserializedObject = xmlSerializer2.Deserialize(stringReader);
            }
        }
    }
}


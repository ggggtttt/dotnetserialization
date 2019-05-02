using System.IO;
using System.Xml.Serialization;
using mvcapp.ExampleClasses;

namespace mvcapp.UseCases
{
    public class UseCaseTen
    {
        public static void Run()
        {
            var xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
            <Simple xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
              xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
              <ID>1</ID>
              <Value xsi:type=""mvcapp.ExampleClasses.ComplexConstructor"">
                <ID>3</ID>
                <Parameters>powershell.exe</Parameters>
              </Value>
            </Simple>";

            var xmlSerializer = new XmlSerializer(typeof(Simple));

            using (StringReader stringReader = new StringReader(xml))
            {
                object deserializedObject = xmlSerializer.Deserialize(stringReader);
            }
        }
    }
}
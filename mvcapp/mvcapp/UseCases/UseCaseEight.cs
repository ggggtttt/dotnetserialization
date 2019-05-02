using System.IO;
using System.Xml.Serialization;
using mvcapp.ExampleClasses;

namespace mvcapp.UseCases
{
    public class UseCaseEight
    {
        public static void Run()
        {
            var simple = new Simple
            {
                ID = 1,
                Value = "Some test string."
            };

            var simple2 = new Simple
            {
                ID = 2,
                Value = "Some test string 2."
            };

            simple.Value = simple2;

            var xmlSerializer = new XmlSerializer(typeof(Simple));

            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, simple);
                string serializedSimple = stringWriter.ToString();
            }
        }
    }
}


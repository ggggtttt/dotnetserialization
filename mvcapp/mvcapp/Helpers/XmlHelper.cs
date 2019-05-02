using System.IO;
using System.Xml.Serialization;

namespace mvcapp.Helpers
{
    public class XmlHelper
    {
        public static string Serialize<T>(T objectToSerialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, objectToSerialize);
                return stringWriter.ToString();
            }
        }

        public static T Deserialize<T>(string toDeserialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(toDeserialize))
            {
                return (T) xmlSerializer.Deserialize(stringReader);
            }
        }
    }
}


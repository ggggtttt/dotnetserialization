using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace mvcapp.UseCases
{
    public class UseCaseFive : ISerializable
    {
        public static void Run()
        {
            var json =
                "{\"$type\":\"mvcapp.ExampleClasses.Simple, mvcapp\",\"ID\":1,\"Value\":{\"$type\":\"mvcapp.ExampleClasses.ComplexConstructor, mvcapp\",\"ID\":2,\"Parameters\":\"powershell.exe\"}}";

            var deserializedTypedObject = JsonConvert.DeserializeObject(json,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            deserializedTypedObject.ToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
using Newtonsoft.Json;

namespace mvcapp.UseCases
{
    public class UseCaseSix
    {
        public static void Run()
        {
            var json =
                "{\"$type\":\"mvcapp.ExampleClasses.Simple, mvcapp\",\"ID\":1,\"Value\":{\"$type\":\"mvcapp.ExampleClasses.ComplexSetter, mvcapp\",\"ID\":2,\"Parameters\":\"powershell.exe\"}}";

            var deserializedTypedObject = JsonConvert.DeserializeObject(json,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            deserializedTypedObject.ToString();
        }
    }
}
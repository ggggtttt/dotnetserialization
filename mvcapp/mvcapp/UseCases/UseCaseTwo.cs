using mvcapp.ExampleClasses;
using Newtonsoft.Json;

namespace mvcapp.UseCases
{
    public class UseCaseTwo
    {
        public static void Run()
        {
            var simple = new Simple
            {
                ID = 1,
                Value = "Some test string."
            };

            var serializedSimple =
                JsonConvert.SerializeObject(simple,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });

            var deserializedSimple =
                JsonConvert.DeserializeObject(serializedSimple);
        }
    }
}
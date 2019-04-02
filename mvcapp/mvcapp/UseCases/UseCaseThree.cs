using mvcapp.ExampleClasses;
using Newtonsoft.Json;

namespace mvcapp.UseCases
{
    public class UseCaseThree
    {
        public static void Run()
        {
            var simpleOne = new Simple
            {
                ID = 1,
                Value = "Some test string."
            };

            var simpleTwo = new Simple
            {
                ID = 2,
                Value = "Some test string 2."
            };

            simpleOne.Value = simpleTwo;

            var serializedSimple =
                JsonConvert.SerializeObject(simpleOne,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });

            var deserializedSimple =
                JsonConvert.DeserializeObject(serializedSimple);
        }
    }
}
using mvcapp.ExampleClasses;
using Newtonsoft.Json;

namespace mvcapp.UseCases
{
    public class UseCaseOne
    {
        public static void Run()
        {
            var simple = new Simple
            {
                ID = 1,
                Value = "Some test string."
            };

            var serializedSimple = 
                JsonConvert.SerializeObject(simple);

            var deserializedSimple = 
                JsonConvert.DeserializeObject(serializedSimple);
        }
    }
}
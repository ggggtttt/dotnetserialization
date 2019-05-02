using System;
using System.IO;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using mvcapp.ExampleClasses;
using mvcapp.UseCases;

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

            //UseCaseOne.Run();
            //UseCaseTwo.Run();
            //UseCaseThree.Run();
            //UseCaseFour.Run();
            //UseCaseFive.Run();
            //UseCaseSix.Run();
            UseCaseSeven.Run();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            //UseCaseEight.Run();
            //UseCaseNine.Run();
            //UseCaseTen.Run();
            UseCaseEleven.Run();

            return View();
        }
    }
}
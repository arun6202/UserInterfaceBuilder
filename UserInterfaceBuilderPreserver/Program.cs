using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using XamarinFormsStarterKit.UserInterfaceBuilder;
using XamarinFormsStarterKit.UserInterfaceBuilder.Preserver;
 
namespace UserInterfaceBuilderPreserver
{
    class Program
    {
        static void Main(string[] args)
        {



            var preserveUIAttributes = new Preserve
            {
                Image = new List<Image> { new Image { Height = 5.6 } }
            };


            XmlSerializer xsSubmit = new XmlSerializer(typeof(Preserve));
            var xml = "";

            using (var sww = new System.IO.StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, preserveUIAttributes);
                    xml = sww.ToString(); // Your XML
                }
            }


            System.Console.Read();
		}
    }
}

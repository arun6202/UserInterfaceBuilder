using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using XamarinFormsStarterKit.UserInterfaceBuilder.Preserver;

namespace UserInterfaceBuilderPreserver
{
    class Program
    {
        static void Main(string[] args)
        {

			var p = new Preserve();


			XmlSerializer xsSubmit = new XmlSerializer(typeof(Preserve));
			var subReq = new Preserve();
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString(); // Your XML
                }
            }


            System.Console.Read();
		}
    }
}

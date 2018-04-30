using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Xamarin.Forms.Mocks;
using XamarinFormsStarterKit.UserInterfaceBuilder;
using XamarinFormsStarterKit.UserInterfaceBuilder.Preserver;
using XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground;
using FFImageLoading.Forms;
 using FFImageLoading.Helpers;
using FFImageLoading.Cache;
using System.Reflection;
using System.Linq;
using FFImageLoading.Work;
using FFImageLoading.Config;
using FFImageLoading;

namespace UserInterfaceBuilderPreserver
{
    class Program
    {
        static void Main(string[] args)
        {
			
			MockForms.Init();

			//ImageService.EnableMockImageService = true;

			MockCachedImageRenderer.Init();
             
			var p = new Playground();

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

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using XamarinFormsStarterKit.UserInterfaceBuilder;
using XamarinFormsStarterKit.UserInterfaceBuilder.Helpers;
using XamarinFormsStarterKit.UserInterfaceBuilder.Preserver;
using XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground;

namespace UserInterfaceBuilderPreserver
{
	class Program
	{
		private const string PreserveXml = "UserInterfaceBuilder/UserInterfaceBuilder/Preserver/Preserve.xml";
		private const string appLocation = @"../../../../../../";

		static void Main(string[] args)
		{
			MockForms.Init();
            
            ComponentBuilder.Init(new ComponentBuilderOptions
            {               
                PreserveSession = true,
                SuppressAllBackGroundColor = false,
				EnableRepeater = true,
				EnableRestorationOfUIAttributes = true,
                EnableTapGestureRecognizers = true,
				EnableUIAttributesGeneration = true
            });

			var playground = new Playground();
			var preserveUIAttributes = ComponentBuilder.PreserveUIAttributes;
             
	     	var projectRoot = Path.GetFullPath(Path.Combine(typeof(Program).Assembly.Location, appLocation));
            var xmlFilePath = Path.Combine(projectRoot, PreserveXml);


			XmlSerializer xs = new XmlSerializer(typeof(Preserve));
            TextWriter txtWriter = new StreamWriter(xmlFilePath);
            xs.Serialize(txtWriter, preserveUIAttributes);
             txtWriter.Close();

			using (StreamReader reader = File.OpenText(xmlFilePath))
            {               
				Console.WriteLine("Generated XML:");
                Console.WriteLine(reader.ReadToEnd());
            }

            Console.WriteLine("XML File Generated!");
  		}
	}
}

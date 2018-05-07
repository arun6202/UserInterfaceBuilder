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
		static void Main(string[] args)
		{
			MockForms.Init();

			var playground = new Playground();
			var preserveUIAttributes = ComponentBuilder.PreserveUIAttributes;

			var appLocation = @"../../../../../../";
          
	     	var projectRoot = Path.GetFullPath(Path.Combine(typeof(Program).Assembly.Location, appLocation));

			var xmlFilePath = Path.Combine(projectRoot, "UserInterfaceBuilder/UserInterfaceBuilder/Preserver/Preserve.xml");


			XmlSerializer xs = new XmlSerializer(typeof(Preserve));

			TextWriter txtWriter = new StreamWriter(xmlFilePath);

			xs.Serialize(txtWriter, preserveUIAttributes);

			txtWriter.Close();

            Console.WriteLine("XML File Generated!");
			Console.Read();
		}
	}
}

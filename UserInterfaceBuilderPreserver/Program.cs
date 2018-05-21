﻿using System;
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

			var playground = new Playground();
			var preserveUIAttributes = ComponentBuilder.PreserveUIAttributes;
             
	     	var projectRoot = Path.GetFullPath(Path.Combine(typeof(Program).Assembly.Location, appLocation));
            var xmlFilePath = Path.Combine(projectRoot, PreserveXml);


			XmlSerializer xs = new XmlSerializer(typeof(Preserve));
            TextWriter txtWriter = new StreamWriter(xmlFilePath);
            xs.Serialize(txtWriter, preserveUIAttributes);
			Console.WriteLine(xs.ToString());
            txtWriter.Close();

            Console.WriteLine("XML File Generated!");
            Console.WriteLine();
 		}
	}
}

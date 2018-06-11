using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using XamarinFormsStarterKit.UserInterfaceBuilder;
using XamarinFormsStarterKit.UserInterfaceBuilder.Helpers;
using XamarinFormsStarterKit.UserInterfaceBuilder.Models;
using XamarinFormsStarterKit.UserInterfaceBuilder.Preserver;
using XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground;

namespace UserInterfaceBuilderPreserver
{
	class Program
	{
		private const string PreserveXml = "XamlPlayground/XamlPlayground/Preserve.xml";
		private const string Xaml = "XamlPlayground/XamlPlayground/Playground.xaml";

		private const string Url = "http://localhost:6202/api";
		private static string baseUri = Url + "/XamlPlaygroundSync";


		private const string appLocation = @"../../../../../../";

		public static async Task Main(string[] args)
		{
			MockForms.Init();

			var componentBuilderOptions = new ComponentBuilderOptions
			{
				PreserveSession = true,
				SuppressAllBackGroundColor = false,
				EnableRepeater = true,
				EnableRestorationOfUIAttributes = true,
				EnableTapGestureRecognizers = true,
				EnableUIAttributesGeneration = true
			};

			var playground = new Playground(componentBuilderOptions);
			var preserveUIAttributes = ComponentBuilder.PreserveUIAttributes;

			var projectRoot = Path.GetFullPath(Path.Combine(typeof(Program).Assembly.Location, appLocation));
			var xmlFilePath = Path.Combine(projectRoot, PreserveXml);
			var xamlFilePath = Path.Combine(projectRoot, Xaml);

			XmlSerializer xs = new XmlSerializer(typeof(Preserve));
			TextWriter txtWriter = new StreamWriter(xmlFilePath);
			xs.Serialize(txtWriter, preserveUIAttributes);
			txtWriter.Close();

			string xml, xaml = string.Empty;

			Console.WriteLine("----------------------------------------------");

			using (StreamReader reader = File.OpenText(xamlFilePath))
			{
				Console.WriteLine("Given XAML:");
				xaml = reader.ReadToEnd();
				Console.WriteLine(xaml);

			}

            Console.WriteLine("----------------------------------------------");

			using (StreamReader reader = File.OpenText(xmlFilePath))
			{
				Console.WriteLine("Generated XML:");
				xml = reader.ReadToEnd();
				Console.WriteLine(xml);

			}

			Console.WriteLine("----------------------------------------------");

			try
			{
				await PostUpdatedXaml(xml, xaml);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}


			Console.WriteLine("XML File Generated!");
		}

		private static async Task PostUpdatedXaml(string preserveXML, string xAML)
		{
			var xamlPayload = new XamlPayload { PreserveXML = preserveXML, XAML = xAML };

			var json = JsonConvert.SerializeObject(xamlPayload);

			Console.WriteLine($"XamlPlaygroundProduce sent: {xamlPayload.XAML} ,{xamlPayload.PreserveXML}");

			var client = new HttpClient
			{
				BaseAddress = new Uri(baseUri)
			};

			var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

			await client.PostAsync(baseUri, stringContent);

		}

	}
}

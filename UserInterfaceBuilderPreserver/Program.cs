using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Xamarin.Forms;
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
        private const string PreserveXaml = "XamlPlayground/XamlPlayground/PreserveXaml.xml";

        private static readonly string XamarinFormsAssembly = "Xamarin.Forms";

        private static readonly string projectRoot = Path.GetFullPath(Path.Combine(typeof(Program).Assembly.Location, appLocation));
        private static readonly string xmlFilePath = Path.Combine(projectRoot, PreserveXml);
        private static readonly string xamlFilePath = Path.Combine(projectRoot, Xaml);
        private static readonly string preserveXamlFilePath = Path.Combine(projectRoot, PreserveXaml);

        private static Type[] VisualElementTypes = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.Contains(XamarinFormsAssembly))
                .SelectMany(s => s.GetTypes())
                .Where(m => !m.IsAbstract)
                                    .Where(typeof(VisualElement).IsAssignableFrom).ToArray();


        private const string Url = "http://localhost:6202/api";
        private static string baseUri = Url + "/XamlPlaygroundSync";


        private const string appLocation = @"../../../../../../";

        public static async Task Main(string[] args)
        {
          var xamlPreserve =  CreatePreserveXaml();
            await Post(xamlPreserve, xamlPreserve);

            return;

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

            await Post(xml, xaml);

            Console.WriteLine("XML File Generated!");
        }

        private static async Task Post(string xml, string xaml)
        {
            try
            {
                await PostUpdatedXaml(xml, xaml);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static  string CreatePreserveXaml()
        {

            XDocument xdoc = XDocument.Load(xamlFilePath);

            RemoveBackGroundColor(xdoc);

            ProcessText(xdoc);

            TraverseXMl(xdoc.Root);

            xdoc.Save(preserveXamlFilePath, SaveOptions.OmitDuplicateNamespaces);

            return xdoc.ToString();

        }

        private static void ProcessText(XDocument xdoc)
        {
            var attributesToDelete = from ele in xdoc.Descendants()
                                     where ele != null && ele.Attribute("Text") != null
                                     select ele;

            try
            {
                foreach (var attribute in attributesToDelete.Attributes())
                {

                    var parent = attribute.Parent;

                    var toDelete = from ele in xdoc.Descendants()
                                                       where ele != null && ele.Attribute("Text") != null
                                             select ele;

                    foreach (var att in toDelete.Attributes())
                    {
                        att.Remove();

                    }

                    parent.SetAttributeValue("TextColor", $"#{LayoutBuilder.GetColor(true).ToHex()}");
                    parent.SetAttributeValue("Text", TextBuilder.GenerateLoremText(attribute.Value));

                 }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void RemoveBackGroundColor(XDocument xdoc)
        {
            var attributesToDelete = from ele in xdoc.Descendants()
                                                         where ele != null && ele.Attribute("BackgroundColor") != null
                                     select ele;

            try
            {
                foreach (var attribute in attributesToDelete.Attributes())
                {
                    attribute.Remove();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void TraverseXMl(XElement xdoc)
        {
            foreach (XElement element in xdoc.Descendants())
            {

                if (VisualElementTypes.Any(w => w.Name == element.Name.LocalName))
                {
                    element.SetAttributeValue("BackgroundColor", $"#{LayoutBuilder.GetColor(true).ToHex()}");

                }

                TraverseXMl(element);
            }
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

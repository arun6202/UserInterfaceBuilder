using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using System.Linq;
using XamarinFormsStarterKit.UserInterfaceBuilder.UIElements;
using SkiaSharp.Views.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
	public static class ImageBuilder
	{
		private const string PNGImageType = ".PNG.Patterns.";
		private const string SVGImageType = ".SVG.Patterns.";

		static readonly List<string> PNGImageList = new List<string>();
		static readonly List<string> SVGImageList = new List<string>();


		static ImageBuilder()
		{
			PNGImageList.AddRange(LoadImagesResourcesList(PNGImageType));
			SVGImageList.AddRange(LoadImagesResourcesList(SVGImageType));

		}

		private static string[] LoadImagesResourcesList(string type)
		{
			var resourceNames = Assembly.GetCallingAssembly().GetManifestResourceNames();

			var resources = resourceNames
				.Where(x => x.Contains(type))
				.ToArray();

			return resources;

		}

		public static void GenerateImage(Layout layout, bool suppressBackGroundColor = true)
		{

			foreach (var child in layout.Children)
			{
				if (child is Layout currentLayout)
				{
					GenerateImage(currentLayout, suppressBackGroundColor);
				}

				var currentControl = (VisualElement)child;



				double height = 44, width = 48;

				switch (child)
				{
					case Image _:
					case SKCanvasView _:
						{
							var imageAttributtes = new Preserver.Image();

							if (suppressBackGroundColor)
							{

								imageAttributtes.BackGroundColor = new Preserver.Color(Color.Default);
							}


							FinalizeDimensions(child, out height, out width);

							if (child is Image img)
							{
								imageAttributtes.Source = RandomPNGImage();

							}

							if (child is SKCanvasView svgImg)
							{
								imageAttributtes.Source = RandomSVGImage();

							}

							imageAttributtes.Height = height;
							imageAttributtes.Width = width;

							ComponentBuilder.PreserveUIAttributes.Image.Add(imageAttributtes);
							break;
						}
				}
			}


		}


		public static void LoadImage(Layout layout, bool apply = true, bool suppressBackGroundColor = true, bool preserveSession = false)
		{
			if (!apply)
			{
				return;
			}

			foreach (var child in layout.Children)
			{
				if (child is Layout currentLayout)
				{
					LoadImage(currentLayout, apply, suppressBackGroundColor);
				}

				var currentControl = (VisualElement)child;


				switch (child)
				{
					case Image _:
					case SKCanvasView _:
						{
							if (suppressBackGroundColor)
							{
								currentControl.BackgroundColor = Color.Default;
							}

							if (child is Image img)
							{
								FinalizeDimensions(child, out double height, out double width);

								img.Source = ImageSource.FromResource(RandomPNGImage());
								img.Aspect = Aspect.Fill;
								img.HeightRequest = height;
								img.WidthRequest = width;

							}

							if (child is SKCanvasView sKCanvas)
							{

								if (sKCanvas.Parent is SVGImage svgImg)
								{
									FinalizeDimensions(sKCanvas, out double height, out double width);

									svgImg.Source = RandomSVGImage();
									svgImg.HeightRequest = height;
									svgImg.WidthRequest = width;
								}

							}
							break;
						}
				}
			}


		}


		private static void FinalizeDimensions(Element element, out double height, out double width)
		{

			var source = "";

			if (element is Image img)
			{
				source = img.Source.ToString();
				source = source.Replace("File:", "").ToLower().Trim();

			}
			if (element is SKCanvasView sKCanvas)
			{
				if (sKCanvas.Parent is SVGImage svgImg)
				{
					source = svgImg.Source;
				}
			}

			height = 40;
			width = 40;
			switch (source)
			{
				case "fs":
					height = 768;
					width = 1024;
					break;

				case "xxxs":
					height = 10;
					width = 10;
					break;

				case "xxs":
					height = 20;
					width = 20;
					break;
				case "xs":
					height = 30;
					width = 30;
					break;
				case "sm":
					height = 40;
					width = 40;
					break;
				case "md":
					height = 60;
					width = 60;
					break;
				case "lg":
					height = 80;
					width = 80;
					break;
				case "xl":
					height = 100;
					width = 100;
					break;
				case "xxl":
					height = 120;
					width = 120;
					break;
				case "xxxl":
					height = 450;
					width = 350;
					break;

				default:
					if (source.Trim() != string.Empty)
					{
						var dimensions = source.Split(new string[] { "/" }, StringSplitOptions.None);

						if (Int32.TryParse(dimensions[0], out int localwidth))
						{
							width = localwidth;
						}

						if (Int32.TryParse(dimensions[1], out int localheight))
						{
							height = localheight;
						}

					}
					else
					{
						height = 30;
						width = 30;

					}

					break;
			}
		}

		static string RandomPNGImage()
		{
			if (PNGImageList.Count == 0)
			{
				PNGImageList.AddRange(LoadImagesResourcesList(PNGImageType));
			}
			var randomIndex = new Random().Next(PNGImageList.Count);
			var img = PNGImageList[randomIndex];
			PNGImageList.RemoveAt(randomIndex);
			return img;
		}

		static string RandomSVGImage()
		{
			if (SVGImageList.Count == 0)
			{
				SVGImageList.AddRange(LoadImagesResourcesList(SVGImageType));
			}
			var randomIndex = new Random().Next(SVGImageList.Count);
			var img = SVGImageList[randomIndex];
			SVGImageList.RemoveAt(randomIndex);
			return img;
		}

	}
}

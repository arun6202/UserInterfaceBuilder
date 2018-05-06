using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using System.Linq;


namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
	public static class ImageBuilder
	{

		static readonly List<string> PNGImageList = new List<string>();


		static ImageBuilder()
		{
			LoadPNGImages();

		}
        
		private static void LoadPNGImages()
		{
			var resourcePaths = LoadPNGImageList();
			PNGImageList.AddRange(resourcePaths);
		}

		private static string[] LoadPNGImageList()
		{
			var resourceNames = Assembly.GetCallingAssembly().GetManifestResourceNames();

			var resourcePaths = resourceNames
				.Where(x => x.Contains(".PNG."))
				.ToArray();
			return resourcePaths;
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

				var imageAttributtes = new Preserver.Image();

				if (suppressBackGroundColor)
				{

					imageAttributtes.BackGroundColor = new Preserver.Color(Color.Default);
				}
                
				if (child is Image img)
				{
					double height, width;
					FinalizeDimensions(img, out height, out width);
					imageAttributtes.Source = RandomImage();
					imageAttributtes.Height = height;
					imageAttributtes.Width = width;
					ComponentBuilder.PreserveUIAttributes.Image.Add(imageAttributtes);

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

				if (suppressBackGroundColor)
				{

					currentControl.BackgroundColor = Color.Transparent;
				}

				if (child is Image img)
				{

					FinalizeDimensions(img, out double height, out double width);
					img.Source = RandomImage();
					img.HeightRequest = height;
					img.WidthRequest = width;

				}

			}


		}


		private static void FinalizeDimensions(Image img, out double height, out double width)
		{
			var source = img.Source.ToString();
			source = source.Replace("File:", "").ToLower().Trim();
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

		static string RandomImage()
		{
			if (PNGImageList.Count == 0)
			{
				LoadPNGImages();
			}
			var randomIndex = new Random().Next(PNGImageList.Count);
			var img = PNGImageList[randomIndex];
			PNGImageList.RemoveAt(randomIndex);
			return img;
		}


	}
}

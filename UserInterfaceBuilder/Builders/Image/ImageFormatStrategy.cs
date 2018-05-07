using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using System.Linq;
using SkiaSharp.Views.Forms;


namespace XamarinFormsStarterKit.UserInterfaceBuilder.Builders.Image
{
	public abstract class ImageFormatStrategy
	{
		protected string ImageType = "PNG";

		protected void ExtractUIAttributes(Element child, Preserver.Image imageAttributtes)
		{
			double height, width;
			FinalizeDimensions(child, out height, out width);
			imageAttributtes.Source = RandomImage(ImageType);
			imageAttributtes.Height = height;
			imageAttributtes.Width = width;
			ComponentBuilder.PreserveUIAttributes.Image.Add(imageAttributtes);

		}

		protected abstract void SetUIAttributes(Element child, object imageAttributtes);

		protected readonly List<string> ImageList = new List<string>();

		protected void LoadImageList(string filter)
		{
			var resourceNames = Assembly.GetCallingAssembly().GetManifestResourceNames();

			var resourcePaths = resourceNames
				.Where(x => x.Contains(filter))
				.ToArray();
			ImageList.AddRange(resourcePaths);
		}

		protected string RandomImage(string filter)
		{
			if (ImageList.Count == 0)
			{
				LoadImageList(filter);
			}
			var randomIndex = new Random().Next(ImageList.Count);
			var img = ImageList[randomIndex];
			ImageList.RemoveAt(randomIndex);
			return img;
		}

		public void GenerateImageAttributes(Layout layout, bool suppressBackGroundColor = true)
		{

			foreach (var child in layout.Children)
			{
				if (child is Layout currentLayout)
				{
					GenerateImageAttributes(currentLayout, suppressBackGroundColor);
				}

				var currentControl = (VisualElement)child;

				var imageAttributtes = new Preserver.Image();

				if (suppressBackGroundColor)
				{

					imageAttributtes.BackGroundColor = new Preserver.Color(Color.Default);
				}

				ExtractUIAttributes(child, imageAttributtes);

			}


		}

		private static void FinalizeDimensions(object image, out double height, out double width)
		{
			var source = "";

			if (image is Xamarin.Forms.Image img)
			{
				source = img.Source.ToString();
			}
			if (image is SKCanvasView svgimg)
			{

			}

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

	}
}

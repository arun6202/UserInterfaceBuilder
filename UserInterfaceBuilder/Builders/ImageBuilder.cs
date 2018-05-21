﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using System.Linq;
using XamarinFormsStarterKit.UserInterfaceBuilder.UIElements;
using SkiaSharp.Views.Forms;
using System.Security;

namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
	public static class ImageBuilder
	{
		private const string PNGImageType = ".PNG.Patterns.";
		private const string SVGImageType = ".SVG.Patterns1.";
		private const double DefaultWidth = 80;
		private const double DefaultHeight = 88;
		private const string Small = "s";
		private const string Medium = "m";
		private const string Large = "l";
		private const string ExtraLarge = "xl";
		private const string DoubleExtraLarge = "xxl";
		private const string TripleExtraLarge = "xxxl";
		private const double SmallSize = 100;
		private const double MediumSize = 140;
		private const double LargeSize = 180;
		private const double ExtraLargeSize = 220;
		private const double DoubleExtraLargeSize = 260;
		private const double TripleExtraLargeSize = 300;
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
				double height = DefaultWidth, width = DefaultHeight;

				switch (child)
				{
					case Image _:
					case SVGImage _:
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
							if (child is SVGImage svgImage)
							{
								imageAttributtes.Source = RandomSVGImage();
								var xml= svgImage.GenerateSVG(height, width).ToString();
								 
								imageAttributtes.Source = SecurityElement.Escape( xml);
                                 
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
					case SVGImage _:
						{
							if (suppressBackGroundColor)
							{
								currentControl.BackgroundColor = Color.Default;
							}
							FinalizeDimensions(child, out double height, out double width);
							if (child is Image img)
							{

								img.Source = ImageSource.FromResource(RandomPNGImage());
								img.Aspect = Aspect.Fill;
								img.HeightRequest = height;
								img.WidthRequest = width;

							}

							if (child is SVGImage svgImg)
							{
								svgImg.Source = RandomSVGImage();
								svgImg.HeightRequest = height;
								svgImg.WidthRequest = width;

							}
							break;
						}
				}
			}


		}


		private static void FinalizeDimensions(Element element, out double height, out double width)
		{
			SVGImage svgImgLocal = new SVGImage();
			var source = "";

			if (element is Image img)
			{
				source = img.Source.ToString();
				source = source.Replace("File:", "").ToLower().Trim();

			}
			if (element is SVGImage svgImg)
			{
				source = svgImg.Source;
				svgImgLocal = svgImg;

			}
			height = DefaultHeight;
			width = DefaultWidth;
			switch (source)
			{
				case Small:
					ConfigureDimensions(SmallSize, ref height, ref width, svgImgLocal);
					break;

				case Medium:
					ConfigureDimensions(MediumSize, ref height, ref width, svgImgLocal);
					break;

				case Large:
					ConfigureDimensions(LargeSize, ref height, ref width, svgImgLocal);
					break;

				case ExtraLarge:
					ConfigureDimensions(ExtraLargeSize, ref height, ref width, svgImgLocal);
					break;

				case DoubleExtraLarge:
					ConfigureDimensions(DoubleExtraLargeSize, ref height, ref width, svgImgLocal);
					break;

				case TripleExtraLarge:
					ConfigureDimensions(TripleExtraLargeSize, ref height, ref width, svgImgLocal);
					break;


				default:
					try
					{
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
					}
					catch
					{
						height = DefaultHeight;
						width = DefaultWidth;

					}

					break;
			}
		}

		private static void ConfigureDimensions(double size, ref double height, ref double width, SVGImage svgImgLocal)
		{
			switch (svgImgLocal.Shape)
			{
				case Shape.Square:
					height = width = size;
					break;
				case Shape.Rectangle10:
					ConfigureRectangle(size, out height, out width, 10);
					break;
				case Shape.Rectangle20:
					ConfigureRectangle(size, out height, out width, 20);
					break;
				case Shape.Rectangle30:
					ConfigureRectangle(size, out height, out width, 30);
					break;
				case Shape.Rectangle40:
					ConfigureRectangle(size, out height, out width, 40);
					break;
				case Shape.RoundedRectangle10:
                    ConfigureRectangle(size, out height, out width, 10);
                    break;
				case Shape.RoundedRectangle20:
                    ConfigureRectangle(size, out height, out width, 20);
                    break;
				case Shape.RoundedRectangle30:
                    ConfigureRectangle(size, out height, out width, 30);
                    break;
				case Shape.RoundedRectangle40:
                    ConfigureRectangle(size, out height, out width, 40);
                    break;
				case Shape.Circle:
					height = width = size;
					break;
				default:
					height = width = size;
					break;
			}
		}

		private static void ConfigureRectangle(double size, out double height, out double width, int factor)
		{
			var proportionalSize = ((int)Math.Round(100 * factor / size));
			height	 = size - proportionalSize;
			width = size + proportionalSize;
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

using System;
using System.IO;
using System.Xml.Linq;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using XamarinFormsStarterKit.UserInterfaceBuilder.Helpers;
using SKSvg = SkiaSharp.Extended.Svg.SKSvg;


namespace XamarinFormsStarterKit.UserInterfaceBuilder.UIElements
{
	public enum Shape
	{
		Square,
		Rectangle10,
		Rectangle20,
		Rectangle30,
		Rectangle40,
		RoundedRectangle10,
		RoundedRectangle20,
		RoundedRectangle30,
		RoundedRectangle40,
        Circle
	}

	public class SVGImage : SKCanvasView
	{
		public static readonly BindableProperty SourceProperty = BindableProperty.Create(
			nameof(Source), typeof(string), typeof(SVGImage), "m", propertyChanged: RedrawCanvas);

		public string Source
		{
			get { return (string)GetValue(SourceProperty); }
			set { SetValue(SourceProperty, value); }

		}

		public static readonly BindableProperty GrowPercentProperty = BindableProperty.Create(
			nameof(GrowPercent), typeof(double), typeof(SVGImage), 100d, propertyChanged: RedrawCanvas);

		public double GrowPercent
		{
			get { return (double)GetValue(GrowPercentProperty); }
			set { SetValue(GrowPercentProperty, value); }

		}

		public static readonly BindableProperty ShapeProperty = BindableProperty.Create(
			nameof(Shape), typeof(Shape), typeof(SVGImage), Shape.Square, propertyChanged: RedrawCanvas);

		public Shape Shape
		{
			get { return (Shape)GetValue(ShapeProperty); }
			set { SetValue(ShapeProperty, value); }

		}
		public SVGImage()
		{
			PaintSurface += CanvasViewOnPaintSurface;
		}

		private static void RedrawCanvas(BindableObject bindable, object oldvalue, object newvalue)
		{
			var svgImage = bindable as SVGImage;
			svgImage?.InvalidateSurface();
		}

		private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
		{
			if (string.IsNullOrEmpty(Source))
				return;

			using (var reader = GenerateSVG().CreateReader())
			{
				var svg = new SKSvg();
				svg.Load(reader);

				var surface = args.Surface;
				var canvas = surface.Canvas;
				canvas.Clear(SKColors.White);

				var canvasMin = Math.Min(WidthRequest, HeightRequest);
				var svgMax = Math.Max(svg.Picture.CullRect.Width, svg.Picture.CullRect.Height);
				var scale = canvasMin / svgMax;
				var matrix = SKMatrix.MakeScale((float)scale, (float)scale);
				//canvas.DrawPicture(svg.Picture, ref matrix);


 				canvas.DrawPicture(svg.Picture, ref matrix);
 

				double dCanvasHeight = 100.0 * Height / args.Info.Height;    
			//	HeightRequest = args.Info.Height;

				double dCanvasWidth = 100.0 * Width / args.Info.Width;
			//	WidthRequest = args.Info.Width;
 
				canvas.DrawPicture(svg.Picture);
                
				canvas.Dispose();
			}
		}
		private const string SVGXml = @"<?xml version='1.0' encoding='UTF-8' ?>
                                        <svg xmlns='http://www.w3.org/2000/svg' 
                                        width ='100%' height ='100%' 
                                        viewBox='0 0 1000 1000' 
                                        preserveAspectRatio='none'>
                                        </svg>";
		static XDocument GenerateSVG()
		{
			var xDocument = XDocument.Parse(SVGXml);

			xDocument.Root.Add(new XElement("rect",
													  new XAttribute("width", "1000"),
													  new XAttribute("height", "1000"),
			                                          new XAttribute("style", "stroke:black;stroke-width:10;opacity:0.5"),
                                                      new XAttribute("fill", LayoutBuilder.RandomColor().ToSKColor().ToString())));


			var gElement = new XElement("g", new XAttribute("fill", LayoutBuilder.RandomColor().ToSKColor().ToString()));

			var seed = new Random().Next(1, 40);
			var increment = new Random().Next(1, 40);

			var reset = seed;

			while (seed <= 1000)
			{
				gElement.Add(new XElement("rect",
													 new XAttribute("width", "1"),
													 new XAttribute("height", "1000"),
										  new XAttribute("x", seed.ToString())));
				seed = seed + increment;
			}

			if (new Random().NextDouble() >= 0.5)
			{
				seed = reset;

			}
			else
			{
				seed = new Random().Next(1, 40);
				increment = new Random().Next(1, 40);
			}

			while (seed <= 1000)
			{

				gElement.Add(new XElement("rect",
												  new XAttribute("width", "1000"),
												  new XAttribute("height", "1"),
									  new XAttribute("y", seed.ToString())));

				seed = seed + increment;

			}

			xDocument.Root.Add(gElement);
            
			return xDocument;


		}

	}
}

using System;
using System.IO;
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
		Rectangle,
		Circle
	}

	public class SVGImage : ContentView
	{

		private readonly SKCanvasView canvasView = new SKCanvasView();

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

			Content = canvasView;
			canvasView.PaintSurface += CanvasViewOnPaintSurface;
		}

		private static void RedrawCanvas(BindableObject bindable, object oldvalue, object newvalue)
		{
			var svgImage = bindable as SVGImage;
			svgImage?.canvasView.InvalidateSurface();
		}

		private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
		{
			if (string.IsNullOrEmpty(Source))
				return;

			using (Stream stream = ResourceLoader.GetEmbeddedResourceStream(Source))
			{
				var svg = new SKSvg();
				svg.Load(stream);

				var surface = args.Surface;
				var canvas = surface.Canvas;
				canvas.Clear(SKColors.White);

				var canvasMin = Math.Min(WidthRequest, HeightRequest);
				var svgMax = Math.Max(svg.Picture.CullRect.Width, svg.Picture.CullRect.Height);
				var scale = canvasMin / svgMax;
				var matrix = SKMatrix.MakeScale((float)scale, (float)scale);

				canvas.DrawPicture(svg.Picture, ref matrix);
			}
		}

	}
}

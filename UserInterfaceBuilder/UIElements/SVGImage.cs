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

		private const Shape DefaultShape = Shape.Square;

		private readonly SKCanvasView canvasView = new SKCanvasView();
  
		public static readonly BindableProperty SourceProperty = BindableProperty.Create(
			nameof(Source), typeof(string), typeof(SVGImage), default(string), propertyChanged: RedrawCanvas);

		public string Source
		{
			get => (string)GetValue(SourceProperty);
			set => SetValue(SourceProperty, value);
		}

		public static readonly BindableProperty SourceGrowPercentageProperty = BindableProperty.Create(
			nameof(SourceGrowPercentage), typeof(double), typeof(SVGImage), 100d, propertyChanged: RedrawCanvas);

		public double SourceGrowPercentage
		{
			get => (double)GetValue(SourceGrowPercentageProperty);
			set => SetValue(SourceGrowPercentageProperty, value);
		}

		public static readonly BindableProperty ShapeProperty = BindableProperty.Create(
			nameof(Shape), typeof(Shape), typeof(SVGImage), DefaultShape, propertyChanged: RedrawCanvas);

		public Shape Shape
        {
			get => (Shape)GetValue(SourceGrowPercentageProperty);
            set => SetValue(SourceGrowPercentageProperty, value);
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

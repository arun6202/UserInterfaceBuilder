using System;
using System.IO;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using XamarinFormsStarterKit.UserInterfaceBuilder.Helpers;
using SKSvg = SkiaSharp.Extended.Svg.SKSvg;


namespace XamarinFormsStarterKit.UserInterfaceBuilder.UIElements
{
    
	public class SVGImage : ContentView
    {
        private readonly SKCanvasView canvasView = new SKCanvasView();

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
            nameof(Source), typeof(string), typeof(SVGImage), default(string), propertyChanged: RedrawCanvas);

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
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

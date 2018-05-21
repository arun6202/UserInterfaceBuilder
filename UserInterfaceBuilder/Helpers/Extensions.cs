using System;
using Xamarin.Forms;
using SkiaSharp.Views.Forms;
using SkiaSharp;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.Helpers
{
	public static class Extensions
	{
		public static Color ToXamarinColor(this Preserver.Color color)
		{
            return Color.FromRgba(color.R, color.G, color.B, color.Hue);
		}
	}
}
    
using System;
using System.Runtime.Serialization;
using XamarinFormsStarterKit.UserInterfaceBuilder.Helpers;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.Preserver
{
	public class Color
	{
		private const string WhiteColor = "#ffffff";

		public Color(Xamarin.Forms.Color color)
		{
			R = color.R;
			G = color.G;
			B = color.B;
			Hue = color.Hue;
			Saturation = color.Saturation;
			Luminosity = color.Luminosity;
			Hex = color.ToHex();
		}

		public Color()
		{

		}
		public double R
		{
			get;
			set;

		}

		public string Hex
		{
			get;
			set;

		} = WhiteColor;

		public double G
		{
			get;
			set;
		}
		public double B
		{
			get;
			set;
		}
		public double Hue
		{
			get;
			set;
		}
		public double Saturation
		{
			get;
			set;
		}
		public double Luminosity
		{
			get;
			set;
		}

	}
}

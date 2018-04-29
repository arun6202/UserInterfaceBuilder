using System;
using System.Runtime.Serialization;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.Preserver
{
    [Serializable]
    [DataContract]
	public class Color
	{
		public Color(Xamarin.Forms.Color color)
		{
			R = color.R;
			G = color.G;
			B = color.B;
			Hue = color.Hue;
			Saturation = color.Saturation;
			Luminosity = color.Luminosity;

		}

        public Color()
		{

		}
        [DataMember]
		public double R
		{
			get;
		}

		public double G
		{
			get;
		}
		public double B
		{
			get;
		}
		public double Hue
		{
			get;
		}
		public double Saturation
		{
			get;
		}
		public double Luminosity
		{
			get;
		}

	}
}

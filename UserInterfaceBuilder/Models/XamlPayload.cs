using System;
namespace XamarinFormsStarterKit.UserInterfaceBuilder.Models
{
	public class XamlPayload : IComparable
	{
		public XamlPayload()
		{
		}

		public string XAML
		{
			get;
			set;
		}

		public string PreserveXML
		{
			get;
			set;
		}

		public int CompareTo(object obj)
		{
			XamlPayload Temp = (XamlPayload)obj;

			return this.XAML.Equals(Temp.XAML) & this.PreserveXML.Equals(Temp.PreserveXML) ? 0 : 1;
		}
	}
}

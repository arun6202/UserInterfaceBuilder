using System;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
	public class ComponentBuilderOptions
	{
		public ComponentBuilderOptions()
		{
			Apply = true;
			PreserveSession = false;

		}

		public View Content
		{
			get;
			set;
		}

		public bool Apply
		{
			get;
			set;
		}

		public bool SuppressAllBackGroundColor
		{
			get;
			set;
		}

		public bool SuppressLayoutBackGroundColor
		{
			get;
			set;
		}

		public bool SuppressImageBackGroundColor
		{
			get;
			set;
		}

		public bool SuppressLoremTextBackGroundColor
		{
			get;
			set;
		}
       
		public bool PreserveSession
        {
            get;
            set;
        }
       
	}
}

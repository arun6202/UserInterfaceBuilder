using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinFormsStarterKit.UserInterfaceBuilder.ViewModels;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.UIElements
{
	public partial class RepeaterContentView : ContentView
	{
		private const int DefaultValue = 1;

		View contentCell;


		public RepeaterContentView()
		{
			InitializeComponent();
			contentCell = repeater.FindByName<View>("contentViewCell");
		}


		public static readonly BindableProperty RepeatCountProperty = BindableProperty.Create(
			nameof(RepeatCount),
			typeof(int),
			typeof(RepeaterContentView),
			DefaultValue,
			BindingMode.OneWay
			);
        

		public int RepeatCount
		{
			get
			{
				return (int)GetValue(RepeatCountProperty);
			}

			set
			{
				SetValue(RepeatCountProperty, value);
				var repeaterVM = new RepeaterViewModel { RepeatCount = value };
				repeater.ItemsSource = repeaterVM.RepeatItems;

			}
		}
		public static readonly BindableProperty RepeaterContentProperty = BindableProperty.Create(
			nameof(RepeaterContent),
			typeof(View),
			typeof(RepeaterContentView),
			DefaultValue,
			BindingMode.OneWay
			);

		public View RepeaterContent
		{
			get
			{
                 
				return contentCell;
			}

			set
			{
				contentCell = value;
			}
		}

	}
}

using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinFormsStarterKit.UserInterfaceBuilder.ViewModels;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.UIElements
{
	public partial class RepeaterContentView : ContentView
	{
		private const int DefaultValue = 1;

		public RepeaterContentView()
		{
			InitializeComponent();
		}


		public static readonly BindableProperty RepeatCountProperty = BindableProperty.Create(
			nameof(RepeatCount),
			typeof(int),
			typeof(RepeaterView),
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
	}
}

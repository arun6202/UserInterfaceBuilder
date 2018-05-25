using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Acr.UserDialogs;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using XamarinFormsStarterKit.UserInterfaceBuilder.Helpers;

namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
	public static class LayoutBuilder
	{

		static readonly List<Color> ColorList = new List<Color>();



		static LayoutBuilder()
		{
			foreach (var item in typeof(Color).GetFields())
			{
				ColorList.Add((Color)item.GetValue(new Color()));

			}

		}

		public static void GenerateLayoutColors(Layout layout, bool suppressBackGroundColor = true)
		{

			var color = GetColor();

			if (suppressBackGroundColor)
			{
				//ComponentBuilder.PreserveUIAttributes.Layout.Add(new Preserver.Color(Color.Default));

			}
			else
			{
				ComponentBuilder.PreserveUIAttributes.Layout.Add(new Preserver.Color(color));

			}

			foreach (var child in layout.Children)
			{
				if (child is Layout currentLayout)
				{
					GenerateLayoutColors(currentLayout, suppressBackGroundColor);
				}
				var currentControl = (VisualElement)child;
				if (child is Layout)
				{


					ComponentBuilder.PreserveUIAttributes.Layout.Add(new Preserver.Color(GetColor()));

				}
				else
				{
					ComponentBuilder.PreserveUIAttributes.Layout.Add(new Preserver.Color(GetColor()));

				}
			}
		}

		internal static void HookTapGestureRecognizer(Layout layout, bool apply)
		{
			if (!apply)
			{
				return;
			}
			foreach (var child in layout.Children)
			{
				if (child is Layout currentLayout)
				{
					HookTapGestureRecognizer(currentLayout, apply);
				}

				EnableToast(child);

			}
		}

		private static void EnableToast(Element child)
		{
			EnableSingleTapToast(child);
			EnableDoubleTapToast(child);
		}

		private static void EnableDoubleTapToast(Element element)
		{
			if (element is VisualElement visualElement)
			{
				if (element is View view)
				{
					var tapGestureRecognizer = new TapGestureRecognizer
					{
						NumberOfTapsRequired = 2
					};
					tapGestureRecognizer.Tapped += (s, e) =>
					{
						Rects.Clear();
						ExtractRect = true;
						ExtractCompleteRect(view);

						UserDialogs.Instance.Toast($"{Rects.ToString()}", TimeSpan.FromSeconds(12));

					};
					view.GestureRecognizers.Add(tapGestureRecognizer);
				}
			}

		}

		static StringBuilder Rects = new StringBuilder();

		static bool ExtractRect = true;

		private static void ExtractCompleteRect(Element element)
		{
			if (element is VisualElement visualElement)
			{
				Rects.AppendLine(visualElement.Bounds.ToSKRect().ToString());

			}
			ExtractRect = !(element.Parent is ContentPage);
			while (ExtractRect )
			{			
				ExtractCompleteRect(element.Parent);
			}

		}


		private static void EnableSingleTapToast(Element element)
		{
			if (element is VisualElement visualElement)
			{
				if (element is View view)
				{
					var tapGestureRecognizer = new TapGestureRecognizer();
					view.GestureRecognizers.Clear();
					tapGestureRecognizer.Tapped += (s, e) =>
					{
						UserDialogs.Instance.Toast($"{view.Bounds.ToSKRect().ToString()}", TimeSpan.FromSeconds(1.5));

					};
					view.GestureRecognizers.Add(tapGestureRecognizer);
				}

			}

		}

		public static void ColorizeLayout(Layout layout, bool apply = true, bool suppressBackGroundColor = true, bool preserveSession = false)
		{
			preserveSession = !preserveSession;
			if (!apply)
			{
				return;
			}

			if (suppressBackGroundColor)
			{
				layout.BackgroundColor = Color.Default;

			}
			else
			{
				layout.BackgroundColor = GetColor(preserveSession);

			}

			foreach (var child in layout.Children)
			{
				if (child is Layout currentLayout)
				{
					ColorizeLayout(currentLayout, apply, suppressBackGroundColor);
				}
				var currentControl = (VisualElement)child;
				if (child is Layout)
				{
					currentControl.BackgroundColor = GetColor(preserveSession);

				}
				else
				{
					currentControl.BackgroundColor = GetColor(preserveSession);

				}
			}
		}

		public static void CompressLayoutAsHeadless(Layout layout, bool apply = true)
		{
			if (!apply)
			{
				return;
			}

			foreach (var child in layout.Children)
			{
				if (child is Layout currentLayout)
				{
					CompressLayoutAsHeadless(currentLayout);
				}

				if (child is Layout currentLayoutHeadless)
				{
					CompressedLayout.SetIsHeadless(child, apply);

				}

			}
		}

		public static Color GetColor(bool isRandom = true)
		{
			if (isRandom)
			{
				if (ColorList.Count == 0)
				{
					foreach (var item in typeof(Color).GetFields())
					{
						ColorList.Add((Color)item.GetValue(new Color()));

					}
				}
				var randomIndex = new Random().Next(ColorList.Count);
				var color = ColorList[randomIndex];
				ColorList.RemoveAt(randomIndex);
				return color;
			}
			else
			{
				try
				{
					if (ComponentBuilder.RestoredUIAttributes.Layout.Any())
					{
						var color = ComponentBuilder.RestoredUIAttributes.Layout[0];
						ComponentBuilder.RestoredUIAttributes.Layout.RemoveAt(0);
						return color.ToXamarinColor();
					}
				}
				finally
				{

				}
			}

			return GetColor(true);
		}
	}
}

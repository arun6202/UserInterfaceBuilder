using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
	public static class LayoutBuilder
	{

		static readonly List<Color> ColorList = new List<Color>();

		internal static   List<Color> PreserveColorList = new List<Color>();

		internal static	bool IsPreserveApplied = false;

		static LayoutBuilder()
		{
			foreach (var item in typeof(Color).GetFields())
			{
				ColorList.Add((Color)item.GetValue(new Color()));

			}

		}

		public static void ColorizeLayout(Layout layout, bool apply = true, bool suppressBackGroundColor = true, bool preserve = true)
		{

			if (!apply)
			{
				return;
			}

			if (suppressBackGroundColor)
			{
				layout.BackgroundColor = Color.Transparent;

			}
			else
			{
				SetBackGroundColor(layout, preserve);

			}



			foreach (var child in layout.Children)
			{
				if (child is Layout currentLayout)
				{
					ColorizeLayout(currentLayout, apply, suppressBackGroundColor);
				}
				var currentControl = (VisualElement)child;
				SetBackGroundColor(child, currentControl, preserve);
			}
		}

		private static void SetBackGroundColor(Element child, VisualElement currentControl, bool preserve)
		{

			if (preserve)
            {
                if (!IsPreserveApplied)
				{
					SetBackGroundColor(child, currentControl);
					PreserveColorList.Add(currentControl.BackgroundColor);
				}

				else
                {
                    if (PreserveColorList.Count != 0)
					{
						SetBackGroundColorPreserve(child, currentControl);

						PreserveColorList.RemoveAt(0);
					}
				}
            }
            else
            {
				SetBackGroundColor(child, currentControl);
                
            }


		}

		private static void SetBackGroundColorPreserve(Element child, VisualElement currentControl)
		{
			if (child is Layout)
			{
				currentControl.BackgroundColor = PreserveColorList[0];

			}
			else
			{
				currentControl.BackgroundColor = PreserveColorList[0];

			}
		}

		private static void SetBackGroundColor(Element child, VisualElement currentControl)
		{
			if (child is Layout)
			{
				currentControl.BackgroundColor = RandomColor();

			}
			else
			{
				currentControl.BackgroundColor = RandomColor();

			}
		}

		private static void SetBackGroundColor(Layout layout, bool preserve)
		{
			if (preserve)
			{
				if (!IsPreserveApplied)
				{
					layout.BackgroundColor = RandomColor();
					PreserveColorList.Add(layout.BackgroundColor);
				}

                else
				{
					if (PreserveColorList.Count!=0)
					{
						layout.BackgroundColor = PreserveColorList[0];
						PreserveColorList.RemoveAt(0);
					}
				}
			}
			else
			{
				layout.BackgroundColor = RandomColor();

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
					CompressedLayout.SetIsHeadless(child, true);

				}

			}
		}

		static Color RandomColor()
		{
			if (ColorList.Count == 0)
			{
				return Color.White; // to do all viable colors are emptied , so please try different layout
			}
			var randomIndex = new Random().Next(ColorList.Count);
			var color = ColorList[randomIndex];
			ColorList.RemoveAt(randomIndex);
			return color;
		}
	}
}

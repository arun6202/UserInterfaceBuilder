using System;
using System.Collections.Generic;
using Xamarin.Forms;

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

			var color = RandomColor();

			if (suppressBackGroundColor)
			{
				ComponentBuilder.PreserveUIAttributes.Layout.Add(new Preserver.Color(Color.Default));

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

 
					ComponentBuilder.PreserveUIAttributes.Layout.Add(new Preserver.Color(RandomColor()));

				}
				else
				{
					ComponentBuilder.PreserveUIAttributes.Layout.Add(new Preserver.Color(RandomColor()));

				}
			}
		}

		public static void ColorizeLayout(Layout layout, bool apply = true, bool suppressBackGroundColor = true, bool preserveSession = false)
		{

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
				layout.BackgroundColor = RandomColor();


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
					currentControl.BackgroundColor = RandomColor();

				}
				else
				{
					currentControl.BackgroundColor = RandomColor();

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
					CompressedLayout.SetIsHeadless(child, true);

				}

			}
		}
        
	public	static Color RandomColor()
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
	}
}

using System;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
	public static class ComponentBuilder
	{

		public static void LoadAllComponents(View content, bool apply = true, bool suppressAllBackGroundColor = false, bool suppressLayoutBackGroundColor = false, bool suppressImageBackGroundColor = false, bool suppressLoremTextBackGroundColor = false)
		{

			var layout = (Layout)content;

			var suppressLayout = false;
			var suppressImage = false;
			var suppressLoremText = false;


			var suppressAll = suppressAllBackGroundColor;
			if (suppressAll)
			{
				suppressLayout = true;
				suppressImage = true;
				suppressLoremText = true;

			}
			else
			{
				suppressLayout = suppressLayoutBackGroundColor;
				suppressImage = suppressImageBackGroundColor;
				suppressLoremText = suppressLoremTextBackGroundColor;
			}


			LayoutBuilder.ColorizeLayout(layout, apply, suppressLayout);
			LayoutBuilder.CompressLayoutAsHeadless(layout, apply);
			ImageBuilder.LoadImage(layout, apply, suppressImage);
			TextBuilder.LoadLoremText(layout, apply, suppressLoremText);
		}

		public static void LoadLayoutComponent(Layout layout, bool apply = true)
		{

			LayoutBuilder.ColorizeLayout(layout, apply);
			LayoutBuilder.CompressLayoutAsHeadless(layout, apply);


		}

		public static void LoadImageComponent(Layout layout, bool apply = true, bool suppressBackGroundColor = true)
		{

			ImageBuilder.LoadImage(layout, apply, suppressBackGroundColor);
		}

		public static void LoadLoremTextComponent(Layout layout, bool apply = true, bool suppressBackGroundColor = true)
		{

			TextBuilder.LoadLoremText(layout, apply, suppressBackGroundColor);
		}
	}
}

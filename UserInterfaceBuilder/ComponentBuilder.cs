using System;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
	public static class ComponentBuilder
	{
		       
		public static void LoadAllComponents(Layout layout, bool apply = true, bool suppressBackGroundColor = false)
		{

			LayoutBuilder.ColorizeLayout(layout, apply,suppressBackGroundColor);
			LayoutBuilder.CompressLayoutAsHeadless(layout, apply);
            ImageBuilder.LoadImage(layout, apply, suppressBackGroundColor);
			TextBuilder.LoadLoremText(layout, apply, suppressBackGroundColor);
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

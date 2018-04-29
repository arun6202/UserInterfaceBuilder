using System;
using Xamarin.Forms;
using XamarinFormsStarterKit.UserInterfaceBuilder.Preserver;

namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
	public static class ComponentBuilder
	{

		public static Preserve PreserveUIAttributes = new Preserve();

        public static void GenerateUIAttributes(ComponentBuilderOptions options)
        {
            ConfigureOptions(options, out Layout layout, out bool suppressLayout, out bool suppressImage, out bool suppressLoremText);

            LayoutBuilder.GenerateLayoutColors(layout, suppressLayout);
            TextBuilder.GenerateLoremText(layout, suppressLoremText);
            ImageBuilder.GenerateImage(layout, suppressImage);
        }
 
		public static void LoadAllComponents(ComponentBuilderOptions options)
		{
            ConfigureOptions(options, out Layout layout, out bool suppressLayout, out bool suppressImage, out bool suppressLoremText);

            LayoutBuilder.ColorizeLayout(layout, options.Apply, suppressLayout, options.PreserveSession);
			LayoutBuilder.CompressLayoutAsHeadless(layout, options.Apply);
			ImageBuilder.LoadImage(layout, options.Apply, suppressImage, options.PreserveSession);
			TextBuilder.LoadLoremText(layout, options.Apply, suppressLoremText, options.PreserveSession);
		}

		private static void ConfigureOptions(ComponentBuilderOptions options, out Layout layout, out bool suppressLayout, out bool suppressImage, out bool suppressLoremText)
        {
            layout = (Layout)options.Content;
            suppressLayout = false;
            suppressImage = false;
            suppressLoremText = false;
            var suppressAll = options.SuppressAllBackGroundColor;
            if (suppressAll)
            {
                suppressLayout = true;
                suppressImage = true;
                suppressLoremText = true;

            }
            else
            {
                suppressLayout = options.SuppressLayoutBackGroundColor;
                suppressImage = options.SuppressImageBackGroundColor;
                suppressLoremText = options.SuppressLoremTextBackGroundColor;
            }
        }

        public static void LoadLayoutComponent(View view, bool apply = true)
		{
			var layout = (Layout)view;


			LayoutBuilder.ColorizeLayout(layout, apply);
			LayoutBuilder.CompressLayoutAsHeadless(layout, apply);


		}

		public static void LoadImageComponent(View view, bool apply = true, bool suppressBackGroundColor = true)
		{
			var layout = (Layout)view;

			ImageBuilder.LoadImage(layout, apply, suppressBackGroundColor);
		}

		public static void LoadLoremTextComponent(View view, bool apply = true, bool suppressBackGroundColor = true)
		{
			var layout = (Layout)view;

			TextBuilder.LoadLoremText(layout, apply, suppressBackGroundColor);
		}
	}
}

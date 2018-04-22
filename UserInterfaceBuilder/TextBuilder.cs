using System;
using System.Collections.Generic;
using System.Reflection;
using Bogus.DataSets;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
    public static class TextBuilder
    {
        static readonly Lorem Lorem = new Lorem();
        static readonly List<Color> ColorList = new List<Color>();
        static TextBuilder()
        {
            foreach (var item in typeof(Color).GetFields())
            {
                ColorList.Add((Color)item.GetValue(new Color()));

            }
        }

        public static void LoadLoremText(Layout layout, bool apply = true, bool suppressBackGroundColor = true)
        {
                    
            if (!apply)
            {
                return;
            }

            foreach (var child in layout.Children)
            {
                if (child is Layout currentLayout)
                {
					LoadLoremText(currentLayout,apply,suppressBackGroundColor);
                }

                if (child.GetType().GetTypeInfo().GetDeclaredProperty("Text") != null)
                {
                    if (suppressBackGroundColor)
                    {
                        var currentControl = (VisualElement)child;
                        currentControl.BackgroundColor = Color.Transparent;
                    }


                    Type type = child.GetType();

                    PropertyInfo prop = type.GetProperty("Text");

                    prop.SetValue(child, GenerateLoremText(prop.GetValue(child).ToString()), null);

                    prop = type.GetProperty("TextColor");

                    prop.SetValue(child, RandomColor(), null);


                }


            }
        }

        private static string GenerateLoremText(string text)
        {
			text = text.ToLower();
            if (text.StartsWith("w", StringComparison.CurrentCulture))
            {
                text = text.Replace("w", string.Empty);
                if (text.Length == 0)
                {
                    text = Lorem.Word();
                }
                else
                {

                    if (Int32.TryParse(text, out int number))
                    {
                        text = string.Join(" ", Lorem.Words(number));
                    }
                }

            }

            if (text.StartsWith("l", StringComparison.CurrentCulture))
            {
                text = text.Replace("l", string.Empty);
                if (text.Length == 0)
                {
                    text = Lorem.Lines();
                }
                else
                {
                    if (Int32.TryParse(text, out int number))
                    {
                        text = string.Join(" ", Lorem.Lines(number));
                    }
                }
            }
            if (text.StartsWith("p", StringComparison.CurrentCulture))
            {
                text = text.Replace("p", string.Empty);
                if (text.Length == 0)
                {
                    text = Lorem.Paragraph();
                }
                else
                {

                    if (Int32.TryParse(text, out int number))
                    {
                        text = string.Join(" ", Lorem.Paragraph(number));
                    }
                }
            }
            if (text.StartsWith("t", StringComparison.CurrentCulture))
            {
                text = text.Replace("t", string.Empty);
                if (text.Length == 0)
                {
                    text = Lorem.Text();
                }

            }
            if (text.StartsWith("sl", StringComparison.CurrentCulture))
            {
                text = text.Replace("sl", string.Empty);
                if (text.Length == 0)
                {
                    text = Lorem.Slug();
                }
                else
                {

                    if (Int32.TryParse(text, out int number))
                    {
                        text = string.Join(" ", Lorem.Slug(number));
                    }
                }
            }

            return text;
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

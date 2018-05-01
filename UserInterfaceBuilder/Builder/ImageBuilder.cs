using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinFormsStarterKit.UserInterfaceBuilder.Helpers;
using XamarinFormsStarterKit.UserInterfaceBuilder.UIElements;

namespace XamarinFormsStarterKit.UserInterfaceBuilder
{
    public static class ImageBuilder
    {

        static readonly List<string> SvgImageList = new List<string>();


        static ImageBuilder()
        {
            foreach (var item in typeof(ImageBuilder).GetFields())
            {
                SvgImageList.Add((string)item.GetValue(new Object()));

            }

        }

        public static void GenerateImage(Layout layout, bool suppressBackGroundColor = true)
        {

            foreach (var child in layout.Children)
            {
                if (child is Layout currentLayout)
                {
                    GenerateImage(currentLayout, suppressBackGroundColor);
                }

                var currentControl = (VisualElement)child;

                var imageAttributtes = new Preserver.Image();

                if (suppressBackGroundColor)
                {

                    imageAttributtes.BackGroundColor = new Preserver.Color(Color.Default);
                }

                if (child is SVGImage img)
                {
                    double height, width;
                    FinalizeDimensions(img, out height, out width);
                    imageAttributtes.Source = RandomImage();
                    imageAttributtes.Height = height;
                    imageAttributtes.Width = width;
                    ComponentBuilder.PreserveUIAttributes.Image.Add(imageAttributtes);

                }

            }


        }


        public static void LoadImage(Layout layout, bool apply = true, bool suppressBackGroundColor = true, bool preserveSession = false)
        {
            if (!apply)
            {
                return;
            }

            foreach (var child in layout.Children)
            {
                if (child is Layout currentLayout)
                {
                    LoadImage(currentLayout, apply, suppressBackGroundColor);
                }

                var currentControl = (VisualElement)child;

                if (suppressBackGroundColor)
                {

                    currentControl.BackgroundColor = Color.Transparent;
                }

                if (child is SVGImage img)
                {

                    FinalizeDimensions(img, out double height, out double width);
                    img.Source = RandomImage();
                    img.HeightRequest = height;
                    img.WidthRequest = width;

                }

            }


        }


        private static void FinalizeDimensions(SVGImage img, out double height, out double width)
        {
            var source = img.Source.ToString();
            source = source.Replace("File:", "").ToLower().Trim();
            height = 40;
            width = 40;
            switch (source)
            {
                case "fs":
                    height = 768;
                    width = 1024;
                    break;

                case "xxxs":
                    height = 10;
                    width = 10;
                    break;

                case "xxs":
                    height = 20;
                    width = 20;
                    break;
                case "xs":
                    height = 30;
                    width = 30;
                    break;
                case "sm":
                    height = 40;
                    width = 40;
                    break;
                case "md":
                    height = 60;
                    width = 60;
                    break;
                case "lg":
                    height = 80;
                    width = 80;
                    break;
                case "xl":
                    height = 100;
                    width = 100;
                    break;
                case "xxl":
                    height = 120;
                    width = 120;
                    break;
                case "xxxl":
                    height = 450;
                    width = 350;
                    break;

                default:
                    if (source.Trim() != string.Empty)
                    {
                        var dimensions = source.Split(new string[] { "/" }, StringSplitOptions.None);

                        if (Int32.TryParse(dimensions[0], out int localwidth))
                        {
                            width = localwidth;
                        }

                        if (Int32.TryParse(dimensions[1], out int localheight))
                        {
                            height = localheight;
                        }

                    }
                    else
                    {
                        height = 40;
                        width = 40;

                    }

                    break;
            }
        }

        static string RandomImage()
        {
            if (SvgImageList.Count == 0)
            {
                return ResourceLoader.GetEmbeddedResourceString("GreenStripes.svg");
            }
            var randomIndex = new Random().Next(SvgImageList.Count);
            var img = SvgImageList[randomIndex];
            SvgImageList.RemoveAt(randomIndex);
            return img;
        }

        public static string HorizontalStripes = "HorizontalStripes.svg";



        public static string GreenStripes = "GreenStripes.svg";



        public static string Honeycomb = "Honeycomb.svg";



        public static string Chevrons = "Chevrons.svg";

        public static string CarbonFiber = "CarbonFiber.svg";



        public static string MicrobialMat = "MicrobialMat.svg";



        public static string Dance = "Dance.svg";



        public static string Checkerboard = "Checkerboard.svg";



        public static string Waves = "Waves.svg";



        public static string VerticalStripes = "VerticalStripes.svg";



        public static string Shippo = "Shippo.svg";



        public static string HalfRombes = "HalfRombes.svg";



        public static string Transparent = "Transparent.svg";



        public static string SimpleHorizontal = "SimpleHorizontal.svg";



        public static string WhiteCarbon = "WhiteCarbon.svg";



        public static string CrossStripes = "CrossStripes.svg";



        public static string SubtleDots = "SubtleDots.svg";



        public static string ThinStripes = "ThinStripes.svg";



        public static string SpeckledNoise = "SpeckledNoise.svg";



        public static string BlueprintGrid = "BlueprintGrid.svg";



        public static string Argyle = "Argyle.svg";




    }
}

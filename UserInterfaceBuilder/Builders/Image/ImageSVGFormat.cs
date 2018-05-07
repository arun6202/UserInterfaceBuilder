using System;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.Builders.Image
{
	public class ImageSVGFormat: ImageFormatStrategy
    {
        public ImageSVGFormat()
        {
			ImageType = "SVG";
			LoadImageList(".SVG.Patterns.");

        }

		protected override void ExtractUIAttributes(Element child, object imageAttributtes)
		{
			throw new NotImplementedException();
		}

		protected override void SetUIAttributes(Element child, object imageAttributtes)
		{
			throw new NotImplementedException();
		}
	}
}

using System;
using Xamarin.Forms;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.Builders.Image
{
	public class ImagePNGFormat:ImageFormatStrategy
    {
		public ImagePNGFormat(Layout layout, bool suppressBackGroundColor = true)
        {
			ImageType = "PNG";
			LoadImageList(".PNG.Patterns.");
			GenerateImageAttributes( layout,  suppressBackGroundColor );
			
        }

         

		protected override void SetUIAttributes(Element child, object imageAttributtes)
		{
			throw new NotImplementedException();
		}
	}
}

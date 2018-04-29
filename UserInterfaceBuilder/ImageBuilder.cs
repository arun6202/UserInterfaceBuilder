using System;
using System.Collections.Generic;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

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

				if (child is SvgCachedImage img)
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

				if (child is SvgCachedImage img)
				{

					FinalizeDimensions(img, out double height, out double width);
					img.Source = RandomImage();
					img.Aspect = Aspect.AspectFill;
					img.HeightRequest = height;
					img.WidthRequest = width;

				}

			}


		}


		private static void FinalizeDimensions(SvgCachedImage img, out double height, out double width)
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
				return "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI2MCIgaGVpZ2h0PSI5MCI+CjxnIHRyYW5zZm9ybT0ic2NhbGUoMSAxLjUpIj4KPHJlY3Qgd2lkdGg9Ijk5IiBoZWlnaHQ9Ijk5IiBmaWxsPSIjNmQ2OTVjIj48L3JlY3Q+CjxyZWN0IHdpZHRoPSI0Mi40MiIgaGVpZ2h0PSI0Mi40MiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMzAgMCkgcm90YXRlKDQ1KSIgZmlsbD0iIzYyNWY1MyI+PC9yZWN0Pgo8cmVjdCB3aWR0aD0iOTkiIGhlaWdodD0iMSIgdHJhbnNmb3JtPSJyb3RhdGUoNDUpIiBmaWxsPSIjNzE2ZjY0Ij48L3JlY3Q+CjxyZWN0IHdpZHRoPSI5OSIgaGVpZ2h0PSIxIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwIDYwKSByb3RhdGUoLTQ1KSIgZmlsbD0iIzcxNmY2NCI+PC9yZWN0Pgo8L2c+Cjwvc3ZnPg==";
			}
			var randomIndex = new Random().Next(SvgImageList.Count);
			var img = SvgImageList[randomIndex];
			SvgImageList.RemoveAt(randomIndex);
			return img;
		}

		public static string horizontalstripes = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI5MCIgaGVpZ2h0PSIzMCI+CjxyZWN0IHdpZHRoPSI5MCIgaGVpZ2h0PSIzMCIgZmlsbD0iIzAwYTlmMSI+PC9yZWN0Pgo8cmVjdCB3aWR0aD0iOTAiIGhlaWdodD0iMTgiIGZpbGw9IiMyNmJhZjQiPjwvcmVjdD4KPC9zdmc+";
		public static string greenstripes = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI3MCIgaGVpZ2h0PSI3MCI+CjxyZWN0IHdpZHRoPSI3MCIgaGVpZ2h0PSI3MCIgZmlsbD0iI2JiZDgxNyI+PC9yZWN0Pgo8ZyB0cmFuc2Zvcm09InJvdGF0ZSg0NSkiPgo8cmVjdCB3aWR0aD0iOTkiIGhlaWdodD0iMjUiIGZpbGw9IiNhOWNlMDAiPjwvcmVjdD4KPHJlY3QgeT0iLTUwIiB3aWR0aD0iOTkiIGhlaWdodD0iMjUiIGZpbGw9IiNhOWNlMDAiPjwvcmVjdD4KPC9nPgo8L3N2Zz4=";
		public static string honeycomb = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI1NiIgaGVpZ2h0PSIxMDAiPgo8cmVjdCB3aWR0aD0iNTYiIGhlaWdodD0iMTAwIiBmaWxsPSIjZjhkMjAzIj48L3JlY3Q+CjxwYXRoIGQ9Ik0yOCA2NkwwIDUwTDAgMTZMMjggMEw1NiAxNkw1NiA1MEwyOCA2NkwyOCAxMDAiIGZpbGw9Im5vbmUiIHN0cm9rZT0iI2ZmZjYyOSIgc3Ryb2tlLXdpZHRoPSIyIj48L3BhdGg+CjxwYXRoIGQ9Ik0yOCAwTDI4IDM0TDAgNTBMMCA4NEwyOCAxMDBMNTYgODRMNTYgNTBMMjggMzQiIGZpbGw9Im5vbmUiIHN0cm9rZT0iI2ZmZTUwMyIgc3Ryb2tlLXdpZHRoPSIyIj48L3BhdGg+Cjwvc3ZnPg==";
		public static string chevrons = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB3aWR0aD0iNjAiIGhlaWdodD0iMzAiPgo8ZGVmcz4KPHJlY3QgaWQ9InIiIHdpZHRoPSIzMCIgaGVpZ2h0PSIxNSIgZmlsbD0iI2JiMDg1ZiIgc3Ryb2tlLXdpZHRoPSIyLjUiIHN0cm9rZT0iIzdhMDU0ZCI+PC9yZWN0Pgo8ZyBpZD0icCI+Cjx1c2UgeGxpbms6aHJlZj0iI3IiPjwvdXNlPgo8dXNlIHk9IjE1IiB4bGluazpocmVmPSIjciI+PC91c2U+Cjx1c2UgeT0iMzAiIHhsaW5rOmhyZWY9IiNyIj48L3VzZT4KPHVzZSB5PSI0NSIgeGxpbms6aHJlZj0iI3IiPjwvdXNlPgo8L2c+CjwvZGVmcz4KPHVzZSB4bGluazpocmVmPSIjcCIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMCAtMjUpIHNrZXdZKDQwKSI+PC91c2U+Cjx1c2UgeGxpbms6aHJlZj0iI3AiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDMwIDApIHNrZXdZKC00MCkiPjwvdXNlPgo8L3N2Zz4=";
		public static string carbonfiber = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxNSIgaGVpZ2h0PSIxNSI+CjxyZWN0IHdpZHRoPSI1MCIgaGVpZ2h0PSI1MCIgZmlsbD0iIzI4MjgyOCI+PC9yZWN0Pgo8Y2lyY2xlIGN4PSIzIiBjeT0iNC4zIiByPSIxLjgiIGZpbGw9IiMzOTM5MzkiPjwvY2lyY2xlPgo8Y2lyY2xlIGN4PSIzIiBjeT0iMyIgcj0iMS44IiBmaWxsPSJibGFjayI+PC9jaXJjbGU+CjxjaXJjbGUgY3g9IjEwLjUiIGN5PSIxMi41IiByPSIxLjgiIGZpbGw9IiMzOTM5MzkiPjwvY2lyY2xlPgo8Y2lyY2xlIGN4PSIxMC41IiBjeT0iMTEuMyIgcj0iMS44IiBmaWxsPSJibGFjayI+PC9jaXJjbGU+Cjwvc3ZnPg==";
		public static string microbialmat = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMCIgaGVpZ2h0PSIyMCI+CjxyZWN0IHdpZHRoPSI0MCIgaGVpZ2h0PSI0MCIgZmlsbD0iIzhhMyI+PC9yZWN0Pgo8Y2lyY2xlIHI9IjkuMiIgc3Ryb2tlLXdpZHRoPSIxIiBzdHJva2U9IiM2MTMiIGZpbGw9Im5vbmUiPjwvY2lyY2xlPgo8Y2lyY2xlIGN5PSIxOC40IiByPSI5LjIiIHN0cm9rZS13aWR0aD0iMXB4IiBzdHJva2U9IiM2MTMiIGZpbGw9Im5vbmUiPjwvY2lyY2xlPgo8Y2lyY2xlIGN4PSIxOC40IiBjeT0iMTguNCIgcj0iOS4yIiBzdHJva2Utd2lkdGg9IjEiIHN0cm9rZT0iIzYxMyIgZmlsbD0ibm9uZSI+PC9jaXJjbGU+Cjwvc3ZnPg==";
		public static string dance = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI4IiBoZWlnaHQ9IjgiPjxwYXRoIGQ9Ik0tMiAxMEwxMCAtMlpNMTAgNkw2IDEwWk0tMiAyTDIgLTIiIHN0cm9rZT0iIzIyMiIgc3Ryb2tlLXdpZHRoPSI0LjUiPjwvcGF0aD4KPC9zdmc+'),url('data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMDAlIiBoZWlnaHQ9IjEwMCUiPgo8bGluZWFyR3JhZGllbnQgaWQ9ImciIHgyPSIxIiB5Mj0iMSI+CjxzdG9wIHN0b3AtY29sb3I9IiNGMTkiPjwvc3RvcD4KPHN0b3Agb2Zmc2V0PSIxMDAlIiBzdG9wLWNvbG9yPSIjMENGIj48L3N0b3A+CjwvbGluZWFyR3JhZGllbnQ+CjxyZWN0IHdpZHRoPSIxMDAlIiBoZWlnaHQ9IjEwMCUiIGZpbGw9InVybCgjZykiPjwvcmVjdD4KPC9zdmc+";
		public static string checkerboard = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI2MCIgaGVpZ2h0PSI2MCI+CjxyZWN0IHdpZHRoPSI2MCIgaGVpZ2h0PSI2MCIgZmlsbD0iI2ZmZiI+PC9yZWN0Pgo8cmVjdCB3aWR0aD0iNDIuNDIiIGhlaWdodD0iNDIuNDIiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDMwIDApIHJvdGF0ZSg0NSkiIGZpbGw9IiM0NDQiPjwvcmVjdD4KPC9zdmc+";
		public static string waves = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI3NSIgaGVpZ2h0PSIxMDAiPgo8cmVjdCB3aWR0aD0iNzUiIGhlaWdodD0iMTAwIiBmaWxsPSJzbGF0ZWdyYXkiPjwvcmVjdD4KPGNpcmNsZSBjeD0iNzUiIGN5PSI1MCIgcj0iMjguMyUiIHN0cm9rZS13aWR0aD0iMTIiIHN0cm9rZT0iIzlhYTZiMiIgZmlsbD0ibm9uZSI+PC9jaXJjbGU+CjxjaXJjbGUgY3g9IjAiIHI9IjI4LjMlIiBzdHJva2Utd2lkdGg9IjEyIiBzdHJva2U9IiM5YWE2YjIiIGZpbGw9Im5vbmUiPjwvY2lyY2xlPgo8Y2lyY2xlIGN5PSIxMDAiIHI9IjI4LjMlIiBzdHJva2Utd2lkdGg9IjEyIiBzdHJva2U9IiM5YWE2YjIiIGZpbGw9Im5vbmUiPjwvY2lyY2xlPgo8L3N2Zz4=";
		public static string verticalstripes = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI1MCIgaGVpZ2h0PSI5MCI+CjxyZWN0IHdpZHRoPSI1MCIgaGVpZ2h0PSI5MCIgZmlsbD0iZ3JleSI+PC9yZWN0Pgo8cmVjdCB4PSIyNSIgd2lkdGg9IjI1IiBoZWlnaHQ9IjkwIiBmaWxsPSIjY2NjIj48L3JlY3Q+Cjwvc3ZnPg==";
		public static string shippo = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI4MCIgaGVpZ2h0PSI4MCI+CjxyZWN0IHdpZHRoPSI4MCIgaGVpZ2h0PSI4MCIgZmlsbD0iIzliYTdiNCI+PC9yZWN0Pgo8Y2lyY2xlIGN4PSI0MCIgY3k9IjQwIiByPSI0MCIgZmlsbD0iI2RlZiI+PC9jaXJjbGU+CjxwYXRoIGQ9Ik0wIDQwIEE0MCA0MCA0NSAwIDAgNDAgMCBBNDAgNDAgMzE1IDAgMCA4MCA0MCBBNDAgNDAgNDUgMCAwIDQwIDgwIEE0MCA0MCAyNzAgMCAwIDAgNDBaIiBmaWxsPSIjOWJhN2I0Ij48L3BhdGg+Cjwvc3ZnPg==";
		public static string halfrombes = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxNSIgaGVpZ2h0PSIxNSI+CjxyZWN0IHdpZHRoPSIxNSIgaGVpZ2h0PSIxNSIgZmlsbD0iIzRmNjM4ZCI+PC9yZWN0Pgo8cGF0aCBkPSJNMCAxNUw3LjUgMEwxNSAxNVoiIGZpbGw9IiMzMDMzNTUiPjwvcGF0aD4KPC9zdmc+";
		public static string transparent = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMCIgaGVpZ2h0PSIyMCI+CjxyZWN0IHdpZHRoPSIyMCIgaGVpZ2h0PSIyMCIgZmlsbD0iI2ZmZiI+PC9yZWN0Pgo8cmVjdCB3aWR0aD0iMTAiIGhlaWdodD0iMTAiIGZpbGw9IiNjY2MiPjwvcmVjdD4KPHJlY3QgeD0iMTAiIHk9IjEwIiB3aWR0aD0iMTAiIGhlaWdodD0iMTAiIGZpbGw9IiNjY2MiPjwvcmVjdD4KPC9zdmc+";
		public static string simplehorizontal = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI5MCIgaGVpZ2h0PSI5Ij4KPHJlY3Qgd2lkdGg9IjkwIiBoZWlnaHQ9IjkiIGZpbGw9IiNmMmYyZjIiPjwvcmVjdD4KPHJlY3Qgd2lkdGg9IjkwIiBoZWlnaHQ9IjIiIGZpbGw9IiNlN2U3ZTciPjwvcmVjdD4KPHJlY3QgeT0iMiIgd2lkdGg9IjkwIiBoZWlnaHQ9IjMiIGZpbGw9IiNlY2VjZWMiPjwvcmVjdD4KPC9zdmc+";
		public static string whitecarbon = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB3aWR0aD0iNiIgaGVpZ2h0PSI2Ij4KPHJlY3Qgd2lkdGg9IjYiIGhlaWdodD0iNiIgZmlsbD0iI2VlZSI+PC9yZWN0Pgo8ZyBpZD0iYyI+CjxyZWN0IHdpZHRoPSIzIiBoZWlnaHQ9IjMiIGZpbGw9IiNlNmU2ZTYiPjwvcmVjdD4KPHJlY3QgeT0iMSIgd2lkdGg9IjMiIGhlaWdodD0iMiIgZmlsbD0iI2Q4ZDhkOCI+PC9yZWN0Pgo8L2c+Cjx1c2UgeGxpbms6aHJlZj0iI2MiIHg9IjMiIHk9IjMiPjwvdXNlPgo8L3N2Zz4=";
		public static string crossstripes = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI4IiBoZWlnaHQ9IjgiPgo8cmVjdCB3aWR0aD0iOCIgaGVpZ2h0PSI4IiBmaWxsPSIjNDAzYzNmIj48L3JlY3Q+CjxwYXRoIGQ9Ik0wIDBMOCA4Wk04IDBMMCA4WiIgc3Ryb2tlLXdpZHRoPSIxIiBzdHJva2U9IiMxZTI5MmQiPjwvcGF0aD4KPC9zdmc+";
		public static string subtledots = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI1IiBoZWlnaHQ9IjUiPgo8cmVjdCB3aWR0aD0iNSIgaGVpZ2h0PSI1IiBmaWxsPSIjZmZmIj48L3JlY3Q+CjxyZWN0IHdpZHRoPSIxIiBoZWlnaHQ9IjEiIGZpbGw9IiNjY2MiPjwvcmVjdD4KPC9zdmc+";
		public static string thinstripes = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI1IiBoZWlnaHQ9IjUiPgo8cmVjdCB3aWR0aD0iNSIgaGVpZ2h0PSI1IiBmaWxsPSIjOWU5ZTllIj48L3JlY3Q+CjxwYXRoIGQ9Ik0wIDVMNSAwWk02IDRMNCA2Wk0tMSAxTDEgLTFaIiBzdHJva2U9IiM4ODgiIHN0cm9rZS13aWR0aD0iMSI+PC9wYXRoPgo8L3N2Zz4=";
		public static string specklednoise = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB3aWR0aD0iNTAwIiBoZWlnaHQ9IjUwMCI+CjxmaWx0ZXIgaWQ9Im4iPgo8ZmVUdXJidWxlbmNlIHR5cGU9ImZyYWN0YWxOb2lzZSIgYmFzZUZyZXF1ZW5jeT0iLjciIG51bU9jdGF2ZXM9IjEwIiBzdGl0Y2hUaWxlcz0ic3RpdGNoIj48L2ZlVHVyYnVsZW5jZT4KPC9maWx0ZXI+CjxyZWN0IHdpZHRoPSI1MDAiIGhlaWdodD0iNTAwIiBmaWxsPSIjMDAwIj48L3JlY3Q+CjxyZWN0IHdpZHRoPSI1MDAiIGhlaWdodD0iNTAwIiBmaWx0ZXI9InVybCgjbikiIG9wYWNpdHk9IjAuNCI+PC9yZWN0Pgo8L3N2Zz4=";
		public static string blueprintgrid = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMDAiIGhlaWdodD0iMTAwIj4KPHJlY3Qgd2lkdGg9IjEwMCIgaGVpZ2h0PSIxMDAiIGZpbGw9IiMyNjkiPjwvcmVjdD4KPGcgZmlsbD0iIzY0OTRiNyI+CjxyZWN0IHdpZHRoPSIxMDAiIGhlaWdodD0iMSIgeT0iMjAiPjwvcmVjdD4KPHJlY3Qgd2lkdGg9IjEwMCIgaGVpZ2h0PSIxIiB5PSI0MCI+PC9yZWN0Pgo8cmVjdCB3aWR0aD0iMTAwIiBoZWlnaHQ9IjEiIHk9IjYwIj48L3JlY3Q+CjxyZWN0IHdpZHRoPSIxMDAiIGhlaWdodD0iMSIgeT0iODAiPjwvcmVjdD4KPHJlY3Qgd2lkdGg9IjEiIGhlaWdodD0iMTAwIiB4PSIyMCI+PC9yZWN0Pgo8cmVjdCB3aWR0aD0iMSIgaGVpZ2h0PSIxMDAiIHg9IjQwIj48L3JlY3Q+CjxyZWN0IHdpZHRoPSIxIiBoZWlnaHQ9IjEwMCIgeD0iNjAiPjwvcmVjdD4KPHJlY3Qgd2lkdGg9IjEiIGhlaWdodD0iMTAwIiB4PSI4MCI+PC9yZWN0Pgo8L2c+CjxyZWN0IHdpZHRoPSIxMDAiIGhlaWdodD0iMTAwIiBmaWxsPSJub25lIiBzdHJva2Utd2lkdGg9IjIiIHN0cm9rZT0iI2ZmZiI+PC9yZWN0Pgo8L3N2Zz4=";
		public static string argyle = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI2MCIgaGVpZ2h0PSI5MCI+CjxnIHRyYW5zZm9ybT0ic2NhbGUoMSAxLjUpIj4KPHJlY3Qgd2lkdGg9Ijk5IiBoZWlnaHQ9Ijk5IiBmaWxsPSIjNmQ2OTVjIj48L3JlY3Q+CjxyZWN0IHdpZHRoPSI0Mi40MiIgaGVpZ2h0PSI0Mi40MiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMzAgMCkgcm90YXRlKDQ1KSIgZmlsbD0iIzYyNWY1MyI+PC9yZWN0Pgo8cmVjdCB3aWR0aD0iOTkiIGhlaWdodD0iMSIgdHJhbnNmb3JtPSJyb3RhdGUoNDUpIiBmaWxsPSIjNzE2ZjY0Ij48L3JlY3Q+CjxyZWN0IHdpZHRoPSI5OSIgaGVpZ2h0PSIxIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwIDYwKSByb3RhdGUoLTQ1KSIgZmlsbD0iIzcxNmY2NCI+PC9yZWN0Pgo8L2c+Cjwvc3ZnPg==";

	}
}

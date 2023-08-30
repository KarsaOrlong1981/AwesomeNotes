using System;
using Microsoft.Maui.Controls;
using RichTextEditor;
using Android.Content;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.AppCompat;
using Microsoft.Maui.Controls.Platform;

[assembly: ExportRenderer(typeof(TestableButton), typeof(ButtonCustomRendererDroid))]
namespace RichTextEditor
{
	public class ButtonCustomRendererDroid : ButtonRenderer
	{
        public ButtonCustomRendererDroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				var button = (TestableButton)e.NewElement;
				button.TestClickHandler += (sender, f) =>
				{
					Control.PerformClick();
				};
			}

		}
	}
}

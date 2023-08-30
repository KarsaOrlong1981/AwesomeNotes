using System;
using Android.Content;
using Microsoft.Maui.Controls;
using RichTextEditor;
using RichTextEditor.Droid;
using Application = Android.App.Application;

//[assembly: Microsoft.Maui.Controls.Dependency(typeof(RegisterEditorDroid))]
namespace RichTextEditor
{
	public class RegisterEditorDroid
	{
		public RegisterEditorDroid(Context context)
		{
			MessagingCenter.Subscribe<HtmlEditor>(this, "register", (editor) =>
			{
				var renderer = new HtmlEditorRendererDroid(context);
				renderer.SetElement(editor);
			});

            MessagingCenter.Subscribe<TestableButton>(this, "register", (button) =>
            {
                var renderer = new ButtonCustomRendererDroid(context);
                renderer.SetElement(button);
            });
        }
	}
}

using System;
using Microsoft.Maui.Controls;

namespace RichTextEditor
{
	public class TestableButton : Button
	{
		public event EventHandler TestClickHandler;

		public TestableButton()
		{
			MessagingCenter.Send(this, "register");
		}

		public void TestClick()
		{
			TestClickHandler(this, EventArgs.Empty);
		}
	}
}

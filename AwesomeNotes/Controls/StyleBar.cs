using System;
using System.Windows.Input;
using AwesomeNotes.EventArguments;
using Microsoft.Maui.Controls;

namespace AwesomeNotes.Controls
{
    public class StyleBar : Microsoft.Maui.Controls.ContentView
    {
        private bool isBold, isItalic, isUnderline;

        protected override void OnParentSet()
        {
            base.OnParentSet();

        }
        public StyleBar()
		{

			var barLayout = new HorizontalStackLayout
			{
				Spacing = 10
			};

            var boldButton = new ImageButton
            {
                Source = "bolda.png",
                Aspect = Aspect.AspectFit,
                BorderColor = Colors.Black,
                BorderWidth = 0.3,
            };


            var italicButton = new ImageButton
            {
                Source = "italicoa.png",
                Aspect = Aspect.AspectFit,
                BorderColor = Colors.Black,
                BorderWidth = 0.3,
               
            };


            var underlineButton = new ImageButton
            {
                Source = "underscore.png",
                Aspect = Aspect.AspectFit,
                BorderColor = Colors.Black,
                BorderWidth = 0.3,
            };

            var acceptButton = new ImageButton
            {
                Source = "accepta.gif",
                Aspect = Aspect.AspectFit,
                BorderColor = Colors.Black,
                BorderWidth = 0.3,
            };

            barLayout.Children.Add(boldButton);
			barLayout.Children.Add(italicButton);
			barLayout.Children.Add(underlineButton);
            barLayout.Children.Add(acceptButton);

            Content = barLayout;

			italicButton.Clicked += (sender, e) =>
			{
                isItalic = !isItalic;

				italicButton.BackgroundColor = isItalic ? Colors.YellowGreen : Colors.White;
				var styleArg = new StyleArgs("italic");
				StyleArgsTransientInstance.StyleArgsTransient.ChangeSytleArgs(styleArg);
			};

			boldButton.Clicked += (sender, e) =>
			{
				isBold = !isBold;
                boldButton.BackgroundColor = isBold ? Colors.YellowGreen : Colors.White;
				var styleArg = new StyleArgs("bold");
                StyleArgsTransientInstance.StyleArgsTransient.ChangeSytleArgs(styleArg);
            };

			underlineButton.Clicked += (sender, e) =>
			{
				isUnderline = !isUnderline;
                underlineButton.BackgroundColor = isUnderline ? Colors.YellowGreen : Colors.White;
				var styleArg = new StyleArgs("underline");
                StyleArgsTransientInstance.StyleArgsTransient.ChangeSytleArgs(styleArg);
            };

            acceptButton.Clicked += (sender, e) =>
            {
                var styleArg = new StyleArgs("accept");
                StyleArgsTransientInstance.StyleArgsTransient.ChangeSytleArgs(styleArg);
            };
        }
	}
}


using System;
using System.Windows.Input;
using FormattableTextEditor;
using Microsoft.Maui.Controls;

namespace RichTextEditor
{
	public class StyleBar : ContentView
	{
        private bool isBold, isItalic, isUnderline, isStrikethrough;

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
                Source = "underscorea.png",
                Aspect = Aspect.AspectFit,
                BorderColor = Colors.Black,
                BorderWidth = 0.3,
            };

            //var strikeThroughButton = new ImageButton
            //{
            //    Source = "striketh.png",
            //    Aspect = Aspect.AspectFit,
            //    BorderColor = Colors.Black,
            //    BorderWidth = 0.3,
            //};

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
            //barLayout.Children.Add(strikeThroughButton);
            barLayout.Children.Add(acceptButton);

            Content = barLayout;

			italicButton.Clicked += (sender, e) =>
			{
                isItalic = !isItalic;

				italicButton.BackgroundColor = isItalic ? Colors.YellowGreen : Colors.White;
				var styleArg = new HtmlEditor.StyleArgs("italic");
				StyleArgsTransientInstance.StyleArgsTransient.ChangeSytleArgs(styleArg);
			};

			boldButton.Clicked += (sender, e) =>
			{
				isBold = !isBold;
                boldButton.BackgroundColor = isBold ? Colors.YellowGreen : Colors.White;
				var styleArg = new HtmlEditor.StyleArgs("bold");
                StyleArgsTransientInstance.StyleArgsTransient.ChangeSytleArgs(styleArg);
            };

			underlineButton.Clicked += (sender, e) =>
			{
				isUnderline = !isUnderline;
                underlineButton.BackgroundColor = isUnderline ? Colors.YellowGreen : Colors.White;
				var styleArg = new HtmlEditor.StyleArgs("underline");
                StyleArgsTransientInstance.StyleArgsTransient.ChangeSytleArgs(styleArg);
            };

            //strikeThroughButton.Clicked += (sender, e) =>
            //{
            //    isStrikethrough = !isStrikethrough;
            //    strikeThroughButton.BackgroundColor = isStrikethrough ? Colors.YellowGreen : Colors.White;
            //    var styleArg = new HtmlEditor.StyleArgs("strikethrough");
            //    StyleArgsTransientInstance.StyleArgsTransient.ChangeSytleArgs(styleArg);
            //};

            acceptButton.Clicked += (sender, e) =>
            {
                var styleArg = new HtmlEditor.StyleArgs("transfertext");
                StyleArgsTransientInstance.StyleArgsTransient.ChangeSytleArgs(styleArg);
            };
        }
	}
}


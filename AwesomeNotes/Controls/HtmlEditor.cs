using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AwesomeNotes.EventArguments;
using Microsoft.Maui.Controls;

namespace AwesomeNotes.Controls
{
    public class HtmlEditor : Editor, INotifyPropertyChanged
	{
		public static StyleBar StaticStyleBar = new StyleBar();

		public event EventHandler HtmlRequested;
		public event EventHandler<HtmlArgs> HtmlSet;
		public event EventHandler<StyleArgs> StyleChangeRequested;
		public event EventHandler<SelectionArgs> SelectionChangeHandler;

		string HtmlString;
		public int SelectionStart;
		public int SelectionEnd;
		private StyleArgsTransient transient;
		

        public static readonly BindableProperty FormattedTextProperty =
        BindableProperty.Create(nameof(FormattedText), typeof(string), typeof(HtmlEditor), "", BindingMode.TwoWay);

		public static readonly BindableProperty CanSetHtmlTextProperty =
		  BindableProperty.Create(nameof(CanSetHtmlText), typeof(bool), typeof(HtmlEditor), false, BindingMode.TwoWay);

        public static readonly BindableProperty EditModeEndsProperty =	
          BindableProperty.Create(nameof(EditModeEnds), typeof(bool), typeof(HtmlEditor), false, BindingMode.TwoWay);

        public string FormattedText
        {
            get => (string)GetValue(FormattedTextProperty);
            set => SetValue(FormattedTextProperty, value);
        }
		public bool CanSetHtmlText
		{
			get => (bool)GetValue(CanSetHtmlTextProperty);
			set => SetValue(CanSetHtmlTextProperty, value);
		}

        public bool EditModeEnds
        {
            get => (bool)GetValue(EditModeEndsProperty);
            set => SetValue(EditModeEndsProperty, value);
        }
        public HtmlEditor()
		{
			this.transient = StyleArgsTransientInstance.StyleArgsTransient;

            this.PropertyChanged += (sender, e) => 
			{
				this.InvalidateMeasure();
			};
            this.transient.ChangeStyleArgsEvent += Transient_ChangeStyleArgsEvent;
            this.StyleChangeRequested += HtmlEditor_StyleChangeRequested;
			
		}

        private void HtmlEditor_StyleChangeRequested(object sender, StyleArgs e)
        {
            if (e.Style == "accept")
			{
				EditModeEnds = true;
			}
        }

        private void Transient_ChangeStyleArgsEvent(object sender, StyleArgs e)
        {
            StyleChangeRequested(this, e);
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
			
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == null) return;

			if (propertyName == nameof(CanSetHtmlText))
			{
				if (CanSetHtmlText)
				{
					FormattedText = GetHtmlText();
					CanSetHtmlText = false;
                }				
			}
			if (propertyName == nameof(EditModeEnds))
			{
				if (EditModeEnds)
				{
					EditModeEnds = false;
				}
			}
		}

		

		public void SetSelection(int start, int end)
		{
			var args = new SelectionArgs(start, end);
			SelectionChangeHandler(this, args);
		}

		public void SetHtmlText(string htmlString)
		{
			HtmlString = htmlString;
			var args = new HtmlArgs(htmlString);
			if(HtmlSet != null) 
			    HtmlSet(this, args);
		}

		public string GetHtmlText()
		{
			if(HtmlRequested != null)
			   HtmlRequested(this, new EventArgs());
			return HtmlString;
		}

		public void BoldChanged()
		{
			StyleChangeRequested(this, new StyleArgs("bold"));
		}

		public void ItalicChanged()
		{
			StyleChangeRequested(this, new StyleArgs("italic"));
		}

		public void UnderlineChanged()
		{
			StyleChangeRequested(this, new StyleArgs("underline"));
		}

	}
}

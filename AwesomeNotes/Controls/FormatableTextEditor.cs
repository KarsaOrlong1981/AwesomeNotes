using AwesomeNotes.Helper;
using AwesomeNotes.Services;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwesomeNotes.Controls
{
    public class FormatableTextEditor : Editor
    {
        public event EventHandler<StyleArgs> StyleChangeRequested;
        public event EventHandler<SelectionArgs> SelectionChangeHandler;
        public int SelectionStart;
        public int SelectionEnd;
        private int startIndex;
        private int endIndex;


        public class StyleArgs : EventArgs
        {
            public string Style;
            public StyleArgs(string style)
            {
                Style = style;
            }
        }
        public class SelectionArgs : EventArgs
        {
            public int Start;
            public int End;
            public SelectionArgs(int start, int end)
            {
                Start = start;
                End = end;
            }
        }

        public FormatableTextEditor()
        {
            StyleChangeRequested += FormatableTextEditor_StyleChangeRequested;
        }

        private void FormatableTextEditor_StyleChangeRequested(object sender, StyleArgs e)
        {
            if (e.Style == "none")
            {

            }
            if (e.Style == "bold")
            {

            }
            if (e.Style == "italic")
            {

            }
            if (e.Style == "boldItalic")
            {

            }
            if (e.Style == "underline")
            {

            }
            if (e.Style == "strikethrough")
            {

            }
        }

        public void SetSelection(int start, int end)
        {
            var args = new SelectionArgs(start, end);
            SelectionChangeHandler(this, args);
        }

        public static readonly BindableProperty FormattedTextProperty =
           BindableProperty.Create(nameof(FormattedText), typeof(FormattedString), typeof(FormatableTextEditor));

        public static readonly BindableProperty IsUnderlineProperty =
            BindableProperty.Create(nameof(IsUnderline), typeof(bool), typeof(FormatableTextEditor), false);

        public static readonly BindableProperty IsBoldProperty =
            BindableProperty.Create(nameof(IsBold), typeof(bool), typeof(FormatableTextEditor), false);

        public static readonly BindableProperty IsItalicProperty =
            BindableProperty.Create(nameof(IsItalic), typeof(bool), typeof(FormatableTextEditor), false);

        public static readonly BindableProperty IsStrikeThroughProperty =
            BindableProperty.Create(nameof(IsStrikeThrough), typeof(bool), typeof(FormatableTextEditor), false);

        public static readonly BindableProperty IsNoneProperty =
           BindableProperty.Create(nameof(IsNone), typeof(bool), typeof(FormatableTextEditor), false);

        public FormattedString FormattedText
        {
            get => (FormattedString)GetValue(FormattedTextProperty);
            set => SetValue(FormattedTextProperty, value);
        }

        public bool IsUnderline
        {
            get => (bool)GetValue(IsUnderlineProperty);
            set => SetValue(IsUnderlineProperty, value);
        }

        public bool IsBold
        {
            get => (bool)GetValue(IsBoldProperty);
            set => SetValue(IsBoldProperty, value);
        }

        public bool IsItalic
        {
            get => (bool)GetValue(IsItalicProperty);
            set => SetValue(IsItalicProperty, value);
        }

        public bool IsStrikeThrough
        {
            get => (bool)(GetValue(IsStrikeThroughProperty));
            set => SetValue(IsStrikeThroughProperty, value);
        }

        public bool IsNone
        {
            get => (bool)GetValue(IsNoneProperty);
            set => SetValue(IsNoneProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == null) return;


            if (propertyName == nameof(IsStrikeThrough))
            {           
                StyleChangeRequested(this, new StyleArgs("strikethrough"));
                IsNone = !IsStrikeThrough && !IsBold && !IsUnderline && !IsItalic ? true : false;
            }
            if (propertyName == nameof(IsUnderline))
            {
                StyleChangeRequested(this, new StyleArgs("underline"));
                IsNone = !IsStrikeThrough && !IsBold && !IsUnderline && !IsItalic ? true : false;
            }
            if (propertyName == nameof(IsBold))
            {
               
                if (IsItalic && IsBold)
                    StyleChangeRequested(this, new StyleArgs("boldItalic"));
                else
                    StyleChangeRequested(this, new StyleArgs("bold"));
                IsNone = !IsStrikeThrough && !IsBold && !IsUnderline && !IsItalic ? true : false;
            }
            if (propertyName == nameof(IsItalic))
            {
                if (IsItalic && IsBold)
                    StyleChangeRequested(this, new StyleArgs("boldItalic"));
                else
                    StyleChangeRequested(this, new StyleArgs("italic"));
                IsNone = !IsStrikeThrough && !IsBold && !IsUnderline && !IsItalic ? true : false;
            }
            if (propertyName == nameof(IsNone))
            {
                if (IsNone)
                    StyleChangeRequested(this, new StyleArgs("none"));
            }
                
        }

    }
}

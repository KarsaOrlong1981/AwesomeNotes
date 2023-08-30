using Android.App.Assist;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Fonts;
using Android.Text;
using Android.Text.Style;
using Android.Widget;
using AwesomeNotes.Controls;
using AwesomeNotes.Helper;
using Java.Lang;
using Java.Time.Format;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AwesomeNotes.Droid
{
    public class FormatableTextEditorRenderer : EditorRenderer
    {
        FormatableTextEditor thisEditor;
        IEditable EditableText;

        public FormatableTextEditorRenderer(Context context) : base(context)
        {   
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
    
            if (e.NewElement != null)
            {
                thisEditor = (FormatableTextEditor)e.NewElement;
                thisEditor.StyleChangeRequested += ThisEditor_StyleChangeRequested;
            }
            if (e.OldElement != null)
            {
                var oldEditor = (FormatableTextEditor)e.OldElement;
                oldEditor.StyleChangeRequested -= ThisEditor_StyleChangeRequested;
            }
        }

        private void ThisEditor_StyleChangeRequested(object sender, FormatableTextEditor.StyleArgs e)
        {
            EditableText = Control.EditableText;
            
            if (e.Style == "none")
            {
                var flag = TypefaceStyle.Normal;
                UpdateStyleSpans(flag);
            }

            if (e.Style == "bold")
            {
                var flag = TypefaceStyle.Bold;
                UpdateStyleSpans(flag);
            }
            else if (e.Style == "italic")
            {
                var flag = TypefaceStyle.Italic;
                UpdateStyleSpans(flag);
            }
            else if (e.Style == "boldItalic")
            {
                var flag = TypefaceStyle.BoldItalic;
                UpdateStyleSpans(flag);
            }
            else if (e.Style == "underline")
            {
                UpdateUnderlineSpans();
            }
            else if (e.Style == "strikethrough")
            {
                UpdateStrikeThroughSpans();
            }
           
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(thisEditor.TextColor))
            {
                Control.SetTextColor(thisEditor.TextColor.ToAndroid());
            }
            if (e.PropertyName == nameof(thisEditor.FontSize))
            {
                Control.TextSize = (float)thisEditor.FontSize;
            }
            if (e.PropertyName == nameof(thisEditor.FontFamily))
            {
                if (!string.IsNullOrEmpty(Element.FontFamily))
                {
                    var fontFamily = FontsHelper.GetCurrentFontString(thisEditor.FontFamily);
                    Typeface face = Typeface.CreateFromAsset(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.Assets, fontFamily);
                    Control.Typeface = face;   
                }
                else
                {
                    Control.Typeface = Typeface.Default;
                }
            }
            Control.SetTextColor(thisEditor.TextColor.ToAndroid());
            SetSelection();
        }

        private void SetSelection()
        {
            thisEditor.SelectionStart = Control.SelectionStart;
            thisEditor.SelectionEnd = Control.SelectionEnd;
        }

        void UpdateStyleSpans(TypefaceStyle flagStyle)
        {
            var selectionStart = Control.SelectionStart;
            var selectionEnd = Control.SelectionEnd;
            var styleSpans = EditableText.GetSpans(selectionStart, selectionEnd, Java.Lang.Class.FromType(typeof(StyleSpan)));
            bool hasFlag = false;
            var spanType = SpanTypes.InclusiveInclusive;
           

            foreach (StyleSpan span in styleSpans)
            {
                var spanStart = EditableText.GetSpanStart(span);
                var spanEnd = EditableText.GetSpanEnd(span);
                var newStart = spanStart;
                var newEnd = spanEnd;
                var startsBefore = false;
                var endsAfter = false;
               

                if (spanStart < selectionStart)
                {
                    newStart = selectionStart;
                    startsBefore = true;
                }
                if (spanEnd > selectionEnd)
                {
                    newEnd = selectionEnd;
                    endsAfter = true;
                }

                if (span.Style == flagStyle)
                {
                    hasFlag = true;

                    EditableText.RemoveSpan(span);

                    EditableText.SetSpan(new StyleSpan(TypefaceStyle.Normal), newStart, newEnd, spanType);

                }
                else if (span.Style == TypefaceStyle.BoldItalic)
                {
                    hasFlag = true;
                    EditableText.RemoveSpan(span);
                  
                    var flagLeft = TypefaceStyle.Bold;
                    if (flagStyle == TypefaceStyle.Bold)
                    {
                        flagLeft = TypefaceStyle.Italic;
                    }
                    EditableText.SetSpan(new StyleSpan(flagLeft), newStart, newEnd, spanType);
                  

                }

                if (startsBefore)
                {
                    EditableText.SetSpan(new StyleSpan(span.Style), spanStart, newStart, SpanTypes.ExclusiveExclusive);
                }
                if (endsAfter)
                {
                    EditableText.SetSpan(new StyleSpan(span.Style), newEnd, spanEnd, SpanTypes.ExclusiveExclusive);
                }

            }
            if (!hasFlag)
            {
                EditableText.SetSpan(new StyleSpan(flagStyle), selectionStart, selectionEnd, spanType);
            }

            SaveChanges(selectionStart, selectionEnd);
        }
       

        void UpdateUnderlineSpans()
        {
            var selectionStart = Control.SelectionStart;
            var selectionEnd = Control.SelectionEnd;
            var underlineSpans = EditableText.GetSpans(selectionStart, selectionEnd, Java.Lang.Class.FromType(typeof(UnderlineSpan)));

            bool hasFlag = false;
            var spanType = SpanTypes.InclusiveInclusive;

            foreach (UnderlineSpan span in underlineSpans)
            {
                hasFlag = true;

                var spanStart = EditableText.GetSpanStart(span);
                var spanEnd = EditableText.GetSpanEnd(span);
                var newStart = spanStart;
                var newEnd = spanEnd;
                var startsBefore = false;
                var endsAfter = false;

                if (spanStart < selectionStart)
                {
                    newStart = selectionStart;
                    startsBefore = true;
                }
                if (spanEnd > selectionEnd)
                {
                    newEnd = selectionEnd;
                    endsAfter = true;
                }

                EditableText.RemoveSpan(span);

                if (startsBefore)
                {
                    EditableText.SetSpan(new UnderlineSpan(), spanStart, newStart, SpanTypes.ExclusiveExclusive);
                }
                if (endsAfter)
                {
                    EditableText.SetSpan(new UnderlineSpan(), newEnd, spanEnd, SpanTypes.ExclusiveExclusive);
                }
            }

            if (!hasFlag)
            {
                EditableText.SetSpan(new UnderlineSpan(), selectionStart, selectionEnd, spanType);
            }

            SaveChanges(selectionStart, selectionEnd);
        }

        void UpdateStrikeThroughSpans() 
        {
            var selectionStart = Control.SelectionStart;
            var selectionEnd = Control.SelectionEnd;
            var strikeThroughSpans = EditableText.GetSpans(selectionStart, selectionEnd, Java.Lang.Class.FromType(typeof(StrikethroughSpan)));

            bool hasFlag = false;
            var spanType = SpanTypes.InclusiveInclusive;

            foreach (StrikethroughSpan span in strikeThroughSpans)
            {
                hasFlag = true;

                var spanStart = EditableText.GetSpanStart(span);
                var spanEnd = EditableText.GetSpanEnd(span);
                var newStart = spanStart;
                var newEnd = spanEnd;
                var startsBefore = false;
                var endsAfter = false;

                if (spanStart < selectionStart)
                {
                    newStart = selectionStart;
                    startsBefore = true;
                }
                if (spanEnd > selectionEnd)
                {
                    newEnd = selectionEnd;
                    endsAfter = true;
                }

                EditableText.RemoveSpan(span);

                if (startsBefore)
                {
                    EditableText.SetSpan(new StrikethroughSpan(), spanStart, newStart, SpanTypes.ExclusiveExclusive);
                }
                if (endsAfter)
                {
                    EditableText.SetSpan(new UnderlineSpan(), newEnd, spanEnd, SpanTypes.ExclusiveExclusive);
                }
            }

            if (!hasFlag)
            {
                EditableText.SetSpan(new StrikethroughSpan(), selectionStart, selectionEnd, spanType);
            }
            
            SaveChanges(selectionStart, selectionEnd);

        }

        void SaveChanges(int selectionStart, int selectionEnd)
        {
            Control.TextFormatted = EditableText;
            Control.RequestFocus();
            Control.SetSelection(selectionStart, selectionEnd);
        }
  
    }
}

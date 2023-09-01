using Android.Content;
using Android.Graphics;
using AwesomeNotes.Droid;
using AwesomeNotes.Helper;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Droid
{
    public class EntryRendererDroid : EntryRenderer
    {
        Entry ThisEntry;
        public EntryRendererDroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            this.ThisEntry = (Entry) e.NewElement;
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ThisEntry.TextColor))
            {
                Control.SetTextColor(ThisEntry.TextColor.ToAndroid());
            }
            if (e.PropertyName == nameof(ThisEntry.BackgroundColor))
            {
                Control.SetBackgroundColor(ThisEntry.BackgroundColor.ToAndroid());
            }
            if (e.PropertyName == nameof(ThisEntry.FontSize))
            {
                Control.TextSize = (float)ThisEntry.FontSize;
            }
            if (e.PropertyName == nameof(ThisEntry.FontFamily))
            {
                if (!string.IsNullOrEmpty(Element.FontFamily))
                {
                    var fontFamily = FontsHelper.GetCurrentFontString(ThisEntry.FontFamily);
                    Typeface face = Typeface.CreateFromAsset(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.Assets, fontFamily);
                    Control.Typeface = face;
                }
                else
                {
                    Control.Typeface = Typeface.Default;
                }
            }
            Control.SetTextColor(ThisEntry.TextColor.ToAndroid());
          
        }
    }
}

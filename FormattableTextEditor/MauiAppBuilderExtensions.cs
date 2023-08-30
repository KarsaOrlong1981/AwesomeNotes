using Microsoft.Maui.Controls.Compatibility.Hosting;
using RichTextEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattableTextEditor
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder UseFormattableTextEditor(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
#if __ANDROID__
                handlers.AddCompatibilityRenderer(typeof(HtmlEditor), typeof(RichTextEditor.Droid.HtmlEditorRendererDroid));
#elif __IOS__
           
#endif

            });

            return builder;
        }
    }
}

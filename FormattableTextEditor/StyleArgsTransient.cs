using RichTextEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RichTextEditor.HtmlEditor;

namespace FormattableTextEditor
{
    public class StyleArgsTransient

    {
        public event EventHandler<StyleArgs> ChangeStyleArgsEvent;

        public void ChangeSytleArgs(StyleArgs args)
        {
           
            ChangeStyleArgsEvent?.Invoke(this, args);
        }

    }
}

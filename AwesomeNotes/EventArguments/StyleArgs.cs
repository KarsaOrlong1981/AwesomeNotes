using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.EventArguments   
{
    public class StyleArgs : EventArgs
    {
        public string Style;
        public StyleArgs(string style)
        {
            Style = style;
        }
    }
}

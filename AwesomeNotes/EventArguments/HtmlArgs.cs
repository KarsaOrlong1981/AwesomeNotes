using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.EventArguments
{
    public class HtmlArgs : EventArgs
    {
        public string HtmlToPass;
        public HtmlArgs(string htmlToPass)
        {
            HtmlToPass = htmlToPass;
        }
    }
}

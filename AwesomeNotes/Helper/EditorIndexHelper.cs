using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Helper
{
    public static class EditorIndexHelper
    {
        // Attributes
        public static int SelectionStartAttributes { get; set; }
        public static int SelectionEndAttributes { get; set;}   
        public static int SpanStartAttributes { get; set; }
        public static int SpanEndAttributes { get; set; }
        public static int NewStartAttributes { get; set;}
        public static int NewEndAttributes { get; set;}

        // Underline
        public static int SelectionStartUnderline { get; set; }
        public static int SelectionEndUnderline { get; set; }   
        public static int SpanStartUnderline { get; set; }
        public static int SpanEndUnderline { get; set; }
        public static int NewStartUnderline { get; set; }
        public static int NewEndUnderline { get; set; }

        // StrikeThrough
        public static int SelectionStartStrike { get; set; }
        public static int SelectionEndStrike { get; set; }
        public static int SpanStartStrike { get; set; }
        public static int SpanEndStrike { get; set; }
        public static int NewStartStrike { get; set; }
        public static int NewEndStrike { get; set; }    
    }
}

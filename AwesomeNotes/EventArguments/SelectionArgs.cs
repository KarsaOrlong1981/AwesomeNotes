using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.EventArguments
{
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
}

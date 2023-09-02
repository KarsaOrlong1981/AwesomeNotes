using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.EventArguments
{
    public class ItemDraggedEventArgs : EventArgs
    {
        public object DraggedItem { get; private set; }
        public int OriginalIndex { get; private set; }
        public int NewIndex { get; private set; }

        public ItemDraggedEventArgs(object draggedItem, int originalIndex, int newIndex)
        {
            DraggedItem = draggedItem;
            OriginalIndex = originalIndex;
            NewIndex = newIndex;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Model
{
    public class Categorie
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Color BackgroundColor { get; set; }  
        public Color TextColor { get; set; }
        public Color SelectedBorderColor { get; set; } = Colors.Transparent;
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Model
{
    public class Categorie : ObservableObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private Color backgroundColor;
        public Color BackgroundColor 
        { 
            get => backgroundColor; 
            set => SetProperty(ref backgroundColor, value, nameof(BackgroundColor));
        }
        private Color textColor;
        public Color TextColor 
        { 
            get => textColor;
            set => SetProperty(ref textColor, value, nameof(TextColor)); 
        }
        private bool isSelected = false;
        public bool IsSelected 
        { 
            get => isSelected;
            set => SetProperty(ref isSelected, value, nameof(IsSelected)); 
        }
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
    }
}

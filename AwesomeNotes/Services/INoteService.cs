using AwesomeNotes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Services
{
    public interface INoteService
    {
        event EventHandler FormattedPropertyChanged;
        void UpdateFormattedText();

        Note GetCurrentNote();
        void SaveNotes(Categorie categorie);
        void SaveCurrentNote(Note note);
        void GetMedia();
        void DeleteMedia();
        void ChangeBackgroundImage();
        void ChangeTextColor();
        void ChangeBackgroundColor();       

    }
}

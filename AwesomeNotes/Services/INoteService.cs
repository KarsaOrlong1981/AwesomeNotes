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
        Note GetNote(int id);
        void SaveNotes(ObservableCollection<Note> notes, string categorie);
        void SaveNote(Note note);
        void GetMedia();
        void DeleteMedia();
        void ChangeBackgroundImage();
        void ChangeTextColor();
        void ChangeBackgroundColor();       

    }
}

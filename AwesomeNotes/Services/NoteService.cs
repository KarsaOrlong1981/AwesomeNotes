using AwesomeNotes.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Services
{
    public class NoteService : INoteService
    {
        public void ChangeBackgroundColor()
        {
            throw new NotImplementedException();
        }

        public void ChangeBackgroundImage()
        {
            throw new NotImplementedException();
        }

        public void ChangeTextColor()
        {
            throw new NotImplementedException();
        }

        public void DeleteMedia()
        {
            throw new NotImplementedException();
        }

        public void GetMedia()
        {
            throw new NotImplementedException();
        }

        public Note GetNote(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveNote(Note note)
        {
            throw new NotImplementedException();
        }

        public void SaveNotes(ObservableCollection<Note> notes, string categorie)
        {
            var serializedList = JsonConvert.SerializeObject(notes);
            Preferences.Default.Set(categorie + "_Notes", serializedList);
        }
    }
}

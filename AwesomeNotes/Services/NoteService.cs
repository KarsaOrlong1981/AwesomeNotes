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
        public event EventHandler FormattedPropertyChanged;

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

        public Note GetCurrentNote()
        {
            Note note = null;
            if (Preferences.Default.ContainsKey("CurrentNote123456"))
            {
                var deserializedNote = Preferences.Default.Get("CurrentNote123456", string.Empty);
                note = JsonConvert.DeserializeObject<Note>(deserializedNote);
            }
            return note;
        }

        public void SaveCurrentNote(Note note)
        {
            var serializedNote = JsonConvert.SerializeObject(note);
            Preferences.Default.Set("CurrentNote123456", serializedNote);
        }

        public void SaveNotes(Categorie categorie)
        {
            var serializedList = JsonConvert.SerializeObject(categorie);
            Preferences.Default.Set(categorie.Name + "_Note1234567", serializedList);
        }

        public void UpdateFormattedText()
        {
            FormattedPropertyChanged?.Invoke(this,EventArgs.Empty);
        }
    }
}

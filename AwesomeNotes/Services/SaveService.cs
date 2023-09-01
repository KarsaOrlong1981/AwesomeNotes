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
    public class SaveService : ISaveService
    {
        public event EventHandler CategoriesChanged; 

        public ObservableCollection<Categorie> GetCategories()
        {
            var categorieList = new ObservableCollection<Categorie>();
            if (Preferences.Default.ContainsKey("CurrentCategorieList"))
            {
                var deSerializedList = Preferences.Default.Get("CurrentCategorieList", string.Empty);
                categorieList = JsonConvert.DeserializeObject<ObservableCollection<Categorie>>(deSerializedList) ?? new ObservableCollection<Categorie>();
            }
            else
            {
                if (categorieList.Count < 3)
                {
                    categorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "Alle Kategorien", Notes = CreateTestingNotes("Alle Kategorien") });
                    categorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "CheckListen" });
                    categorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "Wichtig", Notes = CreateTestingNotes("Wichtig") });
                }

            }
            return categorieList;
            
        }

        public void SaveLastCategorie(string categorie)
        {
            Preferences.Default.Set("LastCategorie", categorie);
        }


        public string GetLastCategorie()
        {
            var lastCategorie = "Alle Kategorien";
            if (Preferences.Default.ContainsKey("LastCategorie"))
            {
                lastCategorie = Preferences.Default.Get("LastCategorie", string.Empty);
            }
            return lastCategorie;
        }

        public void InvokeCategoriesChangedEvent()
        {
            //var serializedList = JsonConvert.SerializeObject(categories);
            //Preferences.Default.Set("OrderedCategorieList", serializedList);
            CategoriesChanged?.Invoke(this, EventArgs.Empty);    
        }


        public void UpdateAllCategories(ObservableCollection<Categorie> categories)
        {
            var serializedList = JsonConvert.SerializeObject(categories);
            Preferences.Default.Set("CurrentCategorieList", serializedList);
        }

        public Note GetCurrentNote()
        {
            Note note = null;
            if (Preferences.Default.ContainsKey("CurrentNote"))
            {
                var deserializedNote = Preferences.Default.Get("CurrentNote", string.Empty);
                note = JsonConvert.DeserializeObject<Note>(deserializedNote);
            }
            return note;
        }

        public void SaveCurrentNote(Note note)
        {
            var serializedNote = JsonConvert.SerializeObject(note);
            Preferences.Default.Set("CurrentNote", serializedNote);
        }

        private ObservableCollection<Note> CreateTestingNotes(string categorie)
        {
            var notes = new ObservableCollection<Note>();
            notes.Add(new Note { Id = "Note1" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 1", Text = "Dies ist eine test Notiz.", FontFamily = "Dino", Categorie = categorie, Background = Colors.Gray, TextColor = Colors.White });
            notes.Add(new Note { Id = "Note2" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 2", Text = "Dies ist eine test Notiz.", FontFamily = "Aqira", Categorie = categorie, Background = Colors.Blue, TextColor = Colors.White });
            notes.Add(new Note { Id = "Note3" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 3", Text = " - Noch möglichkeit zum löschen und hinzufügen von neuen Kategorien./n - die Kategorien (Alle Kategorien, Checklisten und Wichtig dürfen nicht gelöscht werden./n - Checklisetn muss extra seite bekommen um punkte ab zu hacken./n - Noch möglichkeit zur auswahl von bildern und zur aufnahme von Bildern, dazu eine collectionView mit auswahl möglichkeit und fullscreen anzeige./n - Kalendar mit anhängbaren notizen erstellen", FontFamily = "Pamello", Categorie = categorie, Background = Colors.Red, TextColor = Colors.White });
            notes.Add(new Note { Id = "Note4" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 4", Text = "Dies ist eine test Notiz.", FontFamily = "SpicyNachos", Categorie = categorie, Background = Colors.Yellow, TextColor = Colors.Blue });
            notes.Add(new Note { Id = "Note5" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 5", Text = "Dies ist eine test Notiz.", FontFamily = "OpenSansRegular", Categorie = categorie, Background = Colors.Green, TextColor = Colors.White });
            notes.Add(new Note { Id = "Note6" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 6", Text = "Dies ist eine test Notiz.", FontFamily = "Dino", Categorie = categorie, Background = Colors.Violet, TextColor = Colors.White });
            notes.Add(new Note { Id = "Note7" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 7", Text = "Dies ist eine test Notiz.", FontFamily = "Dino", Categorie = categorie, Background = Colors.SteelBlue, TextColor = Colors.White });
            return notes;
        }
    }
}

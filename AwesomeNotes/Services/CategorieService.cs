using AwesomeNotes.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AwesomeNotes.Services
{
    public class CategorieService : ObservableObject, ICategorieService
    {
       
        private ObservableCollection<Categorie> _categories;
        public ObservableCollection<Categorie> CategorieList
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(CategorieList));
            }
        }

        public void DeleteCategorie(Categorie categorie)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategories()
        {
            throw new NotImplementedException();
        }

        public Categorie GetCategorie()
        {
            var categorie = GetCategories().Where(n => n.Name == "Alle Kategorien").FirstOrDefault();
            if (Preferences.Default.ContainsKey("LastCategorie"))
            {
                var dezerializeCategorie = Preferences.Default.Get("LastCategorie", string.Empty);
                categorie = JsonConvert.DeserializeObject<Categorie>(dezerializeCategorie);
            }
            return categorie;
        }

        public ObservableCollection<Categorie> GetCategories()
        {
            if (Preferences.Default.ContainsKey("CategorieList1"))
            {
               var deSerializedList = Preferences.Default.Get("CategorieList1", string.Empty);
               CategorieList = JsonConvert.DeserializeObject<ObservableCollection<Categorie>>(deSerializedList) ?? new ObservableCollection<Categorie>();
            }
            else 
            {
                if (CategorieList.Count < 4)
                {
                    CategorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "Alle Kategorien", Notes = CreateTestingNotes() });
                    CategorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "Einkaufen" });
                    CategorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "Schule", Notes = CreateTestingNotes() });
                    CategorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "Wichtig" });
                }
                
            }
            return CategorieList;
        }

        public void SaveCategorie(Categorie categorie)
        {
            var serializedCategorie = JsonConvert.SerializeObject(categorie);
            Preferences.Default.Set("LastCategorie", serializedCategorie);
        }

        public void SaveCategories(ObservableCollection<Categorie> categories)
        {
            var serializedList = JsonConvert.SerializeObject(categories);
            Preferences.Default.Set("CategorieList1", serializedList);
        }

        public CategorieService()
        {
            CategorieList = new ObservableCollection<Categorie>();
        }

        private ObservableCollection<Note> CreateTestingNotes()
        {
            var notes = new ObservableCollection<Note>();
            notes.Add(new Note { Title = "Note 1", Text = "Dies ist eine test Notiz.", Background = Colors.Gray, TextColor = Colors.White });
            notes.Add(new Note { Title = "Note 2", Text = "Dies ist eine test Notiz.", Background = Colors.Blue, TextColor = Colors.White });
            notes.Add(new Note { Title = "Note 3", Text = "Dies ist eine test Notiz.", Background = Colors.Red, TextColor = Colors.White });
            notes.Add(new Note { Title = "Note 4", Text = "Dies ist eine test Notiz.", Background = Colors.Yellow, TextColor = Colors.Blue });
            notes.Add(new Note { Title = "Note 5", Text = "Dies ist eine test Notiz.", Background = Colors.Green, TextColor = Colors.White });
            notes.Add(new Note { Title = "Note 6", Text = "Dies ist eine test Notiz.", Background = Colors.Violet, TextColor = Colors.White });
            notes.Add(new Note { Title = "Note 7", Text = "Dies ist eine test Notiz.", Background = Colors.SteelBlue, TextColor = Colors.White });
            return notes;
        }

        public void SaveOrderedCategories(ObservableCollection<Categorie> categories)
        {
            SaveCategories(categories);
        }
    }
}

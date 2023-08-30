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

        public event EventHandler UpdateCategoriesEvent;

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
            if (Preferences.Default.ContainsKey("LastCategorie1234567"))
            {
                var dezerializeCategorie = Preferences.Default.Get("LastCategorie1234567", string.Empty);
                categorie = JsonConvert.DeserializeObject<Categorie>(dezerializeCategorie);
            }
            return categorie;
        }

        public ObservableCollection<Categorie> GetCategories()
        {
            if (Preferences.Default.ContainsKey("CategorieList12345678"))
            {
               var deSerializedList = Preferences.Default.Get("CategorieList12345678", string.Empty);
               CategorieList = JsonConvert.DeserializeObject<ObservableCollection<Categorie>>(deSerializedList) ?? new ObservableCollection<Categorie>();
            }
            else 
            {
                if (CategorieList.Count < 4)
                {
                    CategorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "Alle Kategorien", Notes = CreateTestingNotes("Alle Kategorien") });
                    CategorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "Einkaufen" });
                    CategorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "Schule", Notes = CreateTestingNotes("Schule") });
                    CategorieList.Add(new Categorie { BackgroundColor = Colors.White, TextColor = Colors.Blue, Description = "", Name = "Wichtig" });
                }
                
            }
            return CategorieList;
        }
        public void UpdateNotesForCategorie(Categorie categorie)    
        {
            var currentCategories = GetCategories();
            foreach (var cat in currentCategories)
            {
                if (cat.Name == categorie.Name)
                     cat.Notes = categorie.Notes;
               
            }
            SaveCategories(currentCategories);
        }

        public void SaveCategorie(Categorie categorie)
        {
            var serializedCategorie = JsonConvert.SerializeObject(categorie);
            Preferences.Default.Set("LastCategorie1234567", serializedCategorie);
        }

        public void SaveCategories(ObservableCollection<Categorie> categories)
        {
            var serializedList = JsonConvert.SerializeObject(categories);
            Preferences.Default.Set("CategorieList12345678", serializedList);
            UpdateCategoriesEvent?.Invoke(this, EventArgs.Empty);
        }

        public CategorieService()
        {
            CategorieList = new ObservableCollection<Categorie>();
        }

        private ObservableCollection<Note> CreateTestingNotes(string categorie)
        {
            var notes = new ObservableCollection<Note>();
            notes.Add(new Note { Id = "Note1" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 1", Text = "Dies ist eine test Notiz.", FontFamily = "Dino", Categorie = categorie, Background = Colors.Gray, TextColor = Colors.White });
            notes.Add(new Note { Id = "Note2" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 2", Text = "<u>Dies ist eine test Notiz.</u>", FontFamily = "Aqira", Categorie = categorie, Background = Colors.Blue, TextColor = Colors.White });
            notes.Add(new Note { Id = "Note3" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 3", Text = "Dies ist eine test Notiz.", FontFamily = "Pamello", Categorie = categorie, Background = Colors.Red, TextColor = Colors.White });
            notes.Add(new Note { Id = "Note4" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 4", Text = "Dies ist eine test Notiz.", FontFamily = "SpicyNachos", Categorie = categorie, Background = Colors.Yellow, TextColor = Colors.Blue });
            notes.Add(new Note { Id = "Note5" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 5", Text = "Dies ist eine test Notiz.", FontFamily = "OpenSansRegular", Categorie = categorie, Background = Colors.Green, TextColor = Colors.White });
            notes.Add(new Note { Id = "Note6" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 6", Text = "Dies ist eine test Notiz.", FontFamily = "Dino", Categorie = categorie, Background = Colors.Violet, TextColor = Colors.White });
            notes.Add(new Note { Id = "Note7" + Guid.NewGuid().ToString(), FontSize = 20, Title = "Note 7", Text = "Dies ist eine test Notiz.", FontFamily = "Dino", Categorie = categorie, Background = Colors.SteelBlue, TextColor = Colors.White });
            return notes;
        }

        public void SaveOrderedCategories(ObservableCollection<Categorie> categories)
        {
            SaveCategories(categories);
        }

        public Categorie GetCategorieByName(string name)
        {
            var categorie = GetCategories().Where(n => n.Name == name).FirstOrDefault();
            if (Preferences.Default.ContainsKey(name + "_Note1234567"))
            {
               var deserializedCategorie = Preferences.Default.Get(name + "_Note1234567", string.Empty);
               categorie = JsonConvert.DeserializeObject<Categorie>(deserializedCategorie); 
            }
            return categorie;
        }
    }
}

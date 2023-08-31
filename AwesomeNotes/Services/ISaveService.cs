using AwesomeNotes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Services
{
    public interface ISaveService
    {
        event EventHandler CategoriesChanged;
        void SaveLastCategorie(string categorie);
        string GetLastCategorie();  
        void UpdateAllCategories(ObservableCollection<Categorie> categories);     
        void InvokeCategoriesChangedEvent();
        ObservableCollection<Categorie> GetCategories();
        Note GetCurrentNote();
        void SaveCurrentNote(Note note);

    }
}

using AwesomeNotes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Services
{
    public interface ICategorieService
    {
        ObservableCollection<Categorie> CategorieList { get; set; }  
        void SaveCategories(ObservableCollection<Categorie> categories);
        void DeleteCategories();
        void SaveCategorie(Categorie categorie);
        void DeleteCategorie(Categorie categorie);
        void SaveOrderedCategories(ObservableCollection<Categorie> categories);
        ObservableCollection<Categorie> GetCategories();
        Categorie GetCategorie();
    }
}

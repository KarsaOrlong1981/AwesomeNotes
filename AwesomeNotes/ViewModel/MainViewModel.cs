using AwesomeNotes.Helper;
using AwesomeNotes.Model;
using AwesomeNotes.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IServiceProvider provider;

        public MainViewModel(IServiceProvider provider)
        {
            this.provider = provider;
            BackgroundColor = BackgroundHelper.GetBackgroundColor();
            PickedBackColor = BackgroundColor;
            TextColor = BackgroundHelper.GetTextColor();
            PickedTextColor = TextColor;
            Categorie = provider.GetService<ICategorieService>().GetCategorie();
            Notes = Categorie.Notes;
            Categories = provider.GetService<ICategorieService>().GetCategories();
        }
        #region Propertys
        [ObservableProperty]
        private ObservableCollection<Note> notes;

        [ObservableProperty]
        private Color backgroundColor;

        [ObservableProperty]
        private Color textColor;    

        [ObservableProperty]
        private bool canChangeBackground;

        [ObservableProperty]
        private Color pickedBackColor;

        [ObservableProperty]
        private Color pickedTextColor;

        [ObservableProperty]
        private ObservableCollection<Categorie> categories;

        [ObservableProperty]
        private Categorie categorie;

        [ObservableProperty]
        private Note note;

        #endregion

        #region Commands

        [RelayCommand]
        private void CategorieSelectionChanged(Categorie categorie)
        {
            Notes = categorie.Notes;
            Categorie = categorie;
            foreach (var cat in Categories)
            {
                if (cat.Name != categorie.Name) 
                {
                    cat.SelectedBorderColor = Colors.Transparent;
                }
            }
            provider.GetService<ICategorieService>().SaveCategorie(categorie);
        }

        [RelayCommand] 
        private void ChangeBackground()
        {
            CanChangeBackground = true;
        }

        [RelayCommand]
        private void OpenCalendar()
        {

        }

        [RelayCommand]
        private void PickedBackColorChanged()
        {
            BackgroundColor = PickedBackColor;            
        }

        [RelayCommand]
        private void PickedTextColorChanged()   
        {
            TextColor = PickedTextColor;
        }

        [RelayCommand]  
        private void AcceptColor()
        {
            CanChangeBackground = false;
            BackgroundHelper.SaveBackgroundColor(BackgroundColor);
            BackgroundHelper.SaveTextColor(TextColor);
        }

        [RelayCommand]
        private void DragAndDropEnded()
        {
            provider.GetService<ICategorieService>().SaveOrderedCategories(Categories);
        }

        [RelayCommand]
        private void NotesDragAndDropEnded()
        {
            provider.GetService<INoteService>().SaveNotes(Notes, Categorie.Name);
        }
        #endregion 
    }
}

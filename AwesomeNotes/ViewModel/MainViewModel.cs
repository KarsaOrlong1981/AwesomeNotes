using AwesomeNotes.Helper;
using AwesomeNotes.Model;
using AwesomeNotes.Navigation;
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
            ServiceHelper.ServiceProvider = provider;
            BackgroundColor = BackgroundHelper.GetBackgroundColor();
            PickedBackColor = BackgroundColor;
            BackgroundHelper.CurrentBackGround = BackgroundColor;
            TextColor = BackgroundHelper.GetTextColor();
            PickedTextColor = TextColor;
            BackgroundHelper.CurrentTextColor = TextColor;
            Categorie = provider.GetService<ICategorieService>().GetCategorie();
            Notes = Categorie.Notes;
            Categories = provider.GetService<ICategorieService>().GetCategories();
            UpdateCategorie();
            provider.GetService<ICategorieService>().UpdateCategoriesEvent += MainViewModel_UpdateCategoriesEvent;
        }

        private void UpdateCategorie()
        {           
            foreach (var item in Categories)
            {
                if (item.Name == Categorie.Name)
                {
                    item.IsSelected = true;
                    provider.GetService<ICategorieService>().SaveCategorie(item);
                }
                else
                    item.IsSelected = false;

                item.TextColor = TextColor;
                item.BackgroundColor = BackgroundColor;
            }

            OnPropertyChanged(nameof(Categorie));
        }

        private void MainViewModel_UpdateCategoriesEvent(object sender, EventArgs e)
        {
            Categories = provider.GetService<ICategorieService>().GetCategories();
            Categorie = provider.GetService<ICategorieService>().GetCategorie();
            UpdateChangeCategorie(Categorie);
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
            UpdateChangeCategorie(categorie);
            provider.GetService<ICategorieService>().SaveCategorie(categorie);

        }

        private void UpdateChangeCategorie(Categorie categorie)
        {
            Notes = provider.GetService<ICategorieService>().GetCategorieByName(categorie.Name).Notes;
            Categorie = categorie;
            Categorie.IsSelected = true;
            foreach (var cat in Categories)
            {
                if (cat.Name != categorie.Name)
                {
                    cat.IsSelected = false;
                }
                else
                    cat.IsSelected = true;
                cat.BackgroundColor = BackgroundHelper.CurrentBackGround;
                cat.TextColor = BackgroundHelper.CurrentTextColor;
            }
            OnPropertyChanged(nameof(Categorie));
        }

        [RelayCommand]
        private async Task NotesSelectionChanged(Note note) 
        {
            Note = note;
            provider.GetService<INoteService>().SaveCurrentNote(note);
            //BackgroundHelper.CurrentBackGround = BackgroundColor;
            //BackgroundHelper.CurrentTextColor = TextColor;
            await ShellNavigation.GoToDetailAsync("EditNotePage");
            //var action =  await Application.Current.MainPage.DisplayActionSheet(note.Title, "Abbrechen", "", "Lesen/Bearbeiten", "Löschen");
            
        }
        [RelayCommand]
        private void DeleteNote(Note note)
        {
           
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
            BackgroundHelper.CurrentBackGround = BackgroundColor;
          
        }

        [RelayCommand]
        private void PickedTextColorChanged()   
        {
            TextColor = PickedTextColor;
            BackgroundHelper.CurrentTextColor = TextColor;
           
        }

        [RelayCommand]  
        private void AcceptColor()
        {
            CanChangeBackground = false;
            BackgroundHelper.SaveBackgroundColor(BackgroundColor);
            BackgroundHelper.SaveTextColor(TextColor);
           
            foreach (var cat in Categories)
            {
                cat.BackgroundColor = BackgroundHelper.CurrentBackGround;
                cat.TextColor = BackgroundHelper.CurrentTextColor;
            }
            
        }
        [RelayCommand]
        private async Task AddNote()
        {
            await ShellNavigation.GoToDetailAsync("AddNotePage");
        }
        [RelayCommand]
        private void DragAndDropEnded()
        {
            provider.GetService<ICategorieService>().SaveOrderedCategories(Categories);
        }

        [RelayCommand]
        private void NotesDragAndDropEnded()
        {
            Categorie.Notes = Notes;
            provider.GetService<INoteService>().SaveNotes(Categorie);
        }
        #endregion 
    }
}

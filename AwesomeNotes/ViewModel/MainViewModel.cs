using AwesomeNotes.Helper;
using AwesomeNotes.Model;
using AwesomeNotes.Navigation;
using AwesomeNotes.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IServiceProvider provider;

        public MainViewModel()
        {
            this.provider = Ioc.Default.GetService<IServiceProvider>();
            BackgroundColor = BackgroundHelper.GetBackgroundColor();
            PickedBackColor = BackgroundColor;
            BackgroundHelper.CurrentBackGround = BackgroundColor;
            TextColor = BackgroundHelper.GetTextColor();
            PickedTextColor = TextColor;
            BackgroundHelper.CurrentTextColor = TextColor;
            Categories = provider.GetService<ISaveService>().GetCategories();
            Categorie = Categories.Where(c => c.Name == provider.GetService<ISaveService>().GetLastCategorie()).First();
            Notes = Categorie.Notes;
            //sternchen setzen
            UpdateCategorie();

            provider.GetService<ISaveService>().CategoriesChanged += MainViewModel_UpdateCategoriesEvent;
        }

        private void UpdateCategorie()
        {           
            foreach (var item in Categories)
            {
                if (item.Name == Categorie.Name)
                {
                    item.IsSelected = true;
                    provider.GetService<ISaveService>().SaveLastCategorie(item.Name);
                }
                else
                    item.IsSelected = false;

                item.TextColor = TextColor;
                item.BackgroundColor = BackgroundColor;
            }
            provider.GetService<ISaveService>().UpdateAllCategories(Categories);
            OnPropertyChanged(nameof(Categorie));
        }

        private void MainViewModel_UpdateCategoriesEvent(object sender, EventArgs e)
        {
            Categories = provider.GetService<ISaveService>().GetCategories();
            Categorie = Categories.Where(c => c.Name == provider.GetService<ISaveService>().GetLastCategorie()).First();
            Notes = Categorie?.Notes;      
        }
       
        private void UpdateChangeCategorie(Categorie categorie)
        {
            Notes = categorie.Notes;
            Categorie.IsSelected = true;
            foreach (var cat in Categories)
            {
                if (cat.Name != categorie.Name)
                {
                    cat.IsSelected = false;
                }
                else
                {
                    cat.IsSelected = true;
                    provider.GetService<ISaveService>().SaveLastCategorie(cat.Name);
                }
                   
                cat.BackgroundColor = BackgroundHelper.CurrentBackGround;
                cat.TextColor = BackgroundHelper.CurrentTextColor;
            }
            provider.GetService<ISaveService>().UpdateAllCategories(Categories);
            Categorie = Categories.Where(c => c.Name == provider.GetService<ISaveService>().GetLastCategorie()).First();
            OnPropertyChanged(nameof(Categorie));
        }

        #region Propertys

        [ObservableProperty] private ObservableCollection<Note> notes;
        [ObservableProperty] private Color backgroundColor;
        [ObservableProperty] private Color textColor;    
        [ObservableProperty] private bool canChangeBackground;
        [ObservableProperty] private Color pickedBackColor;
        [ObservableProperty] private Color pickedTextColor;
        [ObservableProperty] private ObservableCollection<Categorie> categories;
        [ObservableProperty] private Categorie categorie;
        [ObservableProperty] private Note note;
       

        #endregion

        #region Commands

        [RelayCommand]
        private void CategorieSelectionChanged(Categorie categorie)
        {
            Categorie = categorie;
            UpdateChangeCategorie(categorie);       
        }

       

        [RelayCommand]
        private async Task NotesSelectionChanged(Note note) 
        {
            Note = note;
            provider.GetService<ISaveService>().SaveCurrentNote(note);
            provider.GetService<ISaveService>().UpdateAllCategories(Categories);
            await ShellNavigation.GoToDetailAsync("EditNotePage");      
        }
        [RelayCommand]
        private async Task DeleteNote(Note note)    
        {
            var action =  await Application.Current.MainPage.DisplayAlert(note.Title, "Wollen Sie diese Notiz wirklich Löschen ?","Ja", "Nein");
            if (action)
            {
                Notes.Remove(note);

                foreach (var categorie in Categories)
                {
                    if (categorie.Name == Categorie.Name)
                    {
                        categorie.Notes.Remove(note);
                    }
                }

                provider.GetService<ISaveService>().UpdateAllCategories(Categories);
            }
            
        }
        [RelayCommand]
        private void ShowAttachments()
        {
            // Seite mit collectionView zur auswahl der Bilder im Anhang, bei auswahl eines Bildes
            // soll die PictureView page angezeigt werden und das foto im full screen.

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

        private Categorie dragStartsCategorie;

        [RelayCommand]
        private void DragAndDropStarts(Categorie categorie)
        {
            dragStartsCategorie = categorie;
        }

        private Note dragStartNote;

        [RelayCommand]
        private void NotesDragAndDropStarts(Note note)
        {
            dragStartNote = note;
        }

        private Categorie dragEndsCategorie;

        [RelayCommand]
        private void DragAndDropEnded(Categorie categorie)
        {
            int dragStartIndex = Categories.IndexOf(dragStartsCategorie);
            int dragEndIndex = Categories.IndexOf(categorie);

            var temp = Categories[dragStartIndex];
            Categories[dragStartIndex] = Categories[dragEndIndex];
            Categories[dragEndIndex] = temp;

            OnPropertyChanged(nameof(Categories));
            
            provider.GetService<ISaveService>().UpdateAllCategories(Categories);
            provider.GetService<ISaveService>().InvokeCategoriesChangedEvent();
            
        }

        private Note dragEndsNote;

        [RelayCommand]
        private void NotesDragAndDropEnded(Note note)
        {
            int dragStartIndex = Notes.IndexOf(dragStartNote);
            int dragEndIndex = Notes.IndexOf(note);

            var temp = Notes[dragStartIndex];
            Notes[dragStartIndex] = Notes[dragEndIndex];
            Notes[dragEndIndex] = temp;

            Categorie.Notes = Notes;
            OnPropertyChanged(nameof(Categories));
            provider.GetService<ISaveService>().UpdateAllCategories(Categories);
            
        }
        #endregion 
    }
}

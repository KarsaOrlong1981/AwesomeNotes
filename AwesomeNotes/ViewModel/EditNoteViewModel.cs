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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwesomeNotes.ViewModel
{
    public enum EEditMode { None, FontFamily, FontSize, FontAttributes, Color, Media }
    public partial class EditNoteViewModel : ObservableObject
    {
        private IServiceProvider provider;
        private Categorie categorie;
        private ObservableCollection<Categorie> categories;

        public EditNoteViewModel() 
        {
            this.provider = Ioc.Default.GetService<IServiceProvider>();
            this.Note = provider.GetService<ISaveService>().GetCurrentNote();
            this.categories = provider.GetService<ISaveService>().GetCategories();
            this.categorie = categories.Where(c => c.Name == provider.GetService<ISaveService>().GetLastCategorie()).First();
            this.BackgroundColor = BackgroundHelper.CurrentBackGround;   
            this.TextColor = BackgroundHelper.CurrentTextColor;
            this.FontNames = FontsHelper.GetFontAliasList();
            this.FontSize = Note.FontSize;
            this.EditMode = EEditMode.None;
            this.FormattedText = Note.Text;
            this.EditorText = Note.Text;
            this.PickedImages = new ObservableCollection<ImageSource>();
        }

        private void UpdateCategorie()
        {
            // Update Notes
            for (int i = 0; i < categorie.Notes.Count; i++)
            {
                if (categorie.Notes[i].Id == Note.Id)
                {
                    categorie.Notes[i] = Note;
                    break;
                }
            }
            
            // Update Categories
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].Name == categorie.Name)
                {
                    categories[i] = categorie;
                    break;
                }
            }
            provider.GetService<ISaveService>().UpdateAllCategories(categories);
        }
       
        #region Propertys

        [ObservableProperty] private Color backgroundColor;  
        [ObservableProperty] private Color textColor;
        [ObservableProperty] private Note note;
        [ObservableProperty] private EEditMode editMode; 
        [ObservableProperty] private List<string> fontNames;
        [ObservableProperty] private string font;
        [ObservableProperty] private double fontSize = 20;
        [ObservableProperty] private string formattedText;
        [ObservableProperty] private string editorText;
        [ObservableProperty] private Color pickedBackColor;
        [ObservableProperty] private Color pickedTextColor;
        [ObservableProperty] private ImageSource pickedImage;
        [ObservableProperty] private ObservableCollection<ImageSource> pickedImages;

        private bool canSetHtmlText;
        public bool CanSetHtmlText
        {
            get => canSetHtmlText;
            set
            {
               
                canSetHtmlText = value; 
                OnPropertyChanged(nameof(CanSetHtmlText));
            }
        }
        private bool editModeEnds;
        public bool EditModeEnds
        {
            get => editModeEnds;
            set
            {

                editModeEnds = value;
                if (editModeEnds)
                {
                    EditMode = EEditMode.None;
                }
                OnPropertyChanged(nameof(EditModeEnds));
            }
        }
        #endregion
        #region Commands

        [RelayCommand]
        private void ChangeFontFamily()
        {
            EditMode = EEditMode.FontFamily;
        }
        [RelayCommand]
        private void ChangeFontSize() 
        {
            EditMode = EEditMode.FontSize;
        }

        [RelayCommand]
        private void FontFamilyChanged()
        {
            Note.FontFamily = Font;
            UpdateCategorie();
            EditMode = EEditMode.None;
        }
        [RelayCommand]
        private void FontSizeChanged(double value)
        {
            Note.FontSize = value;
            UpdateCategorie();
        }
        [RelayCommand]
        private async Task AcceptChanges()
        {
            CanSetHtmlText = true;
            Note.Text = FormattedText;
            UpdateCategorie();
            provider.GetService<ISaveService>().InvokeCategoriesChangedEvent();
            
            await ShellNavigation.GoToPageAsync("MainPage");
            
        }
        [RelayCommand]
        private void FontSizeFinished()
        {
            EditMode = EEditMode.None;
        }

        [RelayCommand]
        private void ChnageFontAttributes()
        {
            EditMode = EEditMode.FontAttributes;         
        }

        [RelayCommand]
        private void AcceptAttributes()
        {
            EditMode = EEditMode.None;
        }
        [RelayCommand]
        private void ChangeColor()
        {
            EditMode |= EEditMode.Color;
        }

        [RelayCommand]
        private void PickedBackColorChanged()
        {
            Note.Background = PickedBackColor;
          
        }

        [RelayCommand]
        private void PickedTextColorChanged()
        {
           Note.TextColor = PickedTextColor;
           

        }

        [RelayCommand]
        private void AcceptColor()
        {
            EditMode = EEditMode.None;

        }

        [RelayCommand]
        private void AddMedia()
        {
            Application.Current.Dispatcher.Dispatch(async () =>
            {
                var result = await MediaPicker.PickPhotoAsync();

                if (result != null)
                {
                    PickedImage = ImageSource.FromFile(result.FullPath);
                    PickedImages.Add(PickedImage);
                    Note.ImageSources.Add(PickedImage);
                    Note.HasAttachments = true;
                    UpdateCategorie();
                }

            });
        }

        [RelayCommand]
        private void CapturePhoto()
        {
            Application.Current.Dispatcher.Dispatch(async () =>
            {
                var result = await MediaPicker.CapturePhotoAsync();

                if (result != null)
                {
                    PickedImage = ImageSource.FromFile(result.FullPath);
                    PickedImages.Add(PickedImage);
                    Note.ImageSources.Add(PickedImage);
                    Note.HasAttachments = true;
                    UpdateCategorie();
                }

            });
        }
        #endregion
    }
}

using AwesomeNotes.Helper;
using AwesomeNotes.Model;
using AwesomeNotes.Navigation;
using AwesomeNotes.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwesomeNotes.ViewModel
{
    public enum EeditMode { None, FontFamily, FontSize, FontAttributes, Color, Media }
    public partial class EditNoteViewModel : ObservableObject
    {
        private IServiceProvider provider;
        private Categorie categorie;
       

        public EditNoteViewModel() 
        {
            this.provider = ServiceHelper.ServiceProvider;
            this.Note = provider.GetService<INoteService>().GetCurrentNote();
            this.categorie = provider.GetService<ICategorieService>().GetCategorie();
            this.BackgroundColor = BackgroundHelper.CurrentBackGround;   
            this.TextColor = BackgroundHelper.CurrentTextColor;
            this.FontNames = FontsHelper.GetFontAliasList();
            this.FontSize = Note.FontSize;
            this.EditMode = EeditMode.None;
            this.FormattedText = Note.Text;
            this.EditorText = Note.Text;
        }

        private void UpdateCategorie()
        {
            
            for (int i = 0; i < categorie.Notes.Count; i++)
            {
                if (categorie.Notes[i].Id == Note.Id)
                {
                    categorie.Notes[i] = Note;
                    break;
                }
            }
            provider.GetService<ICategorieService>().SaveCategorie(categorie);
            
        }
       
        #region Propertys

        [ObservableProperty] private Color backgroundColor;  
        [ObservableProperty] private Color textColor;
        [ObservableProperty] private Note note;
        [ObservableProperty] private EeditMode editMode; 
        [ObservableProperty] private List<string> fontNames;
        [ObservableProperty] private string font;
        [ObservableProperty] private double fontSize = 20;
        [ObservableProperty] private string formattedText;
        [ObservableProperty] private bool canSetHtmlText;
        [ObservableProperty] private string editorText;


        #endregion
        #region Commands

        [RelayCommand]
        private void ChangeFontFamily()
        {
            EditMode = EeditMode.FontFamily;
        }
        [RelayCommand]
        private void ChangeFontSize() 
        {
            EditMode = EeditMode.FontSize;
        }

        [RelayCommand]
        private void FontFamilyChanged()
        {
            Note.FontFamily = Font;
            UpdateCategorie();
            EditMode = EeditMode.None;
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
            
            provider.GetService<ICategorieService>().UpdateNotesForCategorie(categorie);
            await ShellNavigation.GoToPageAsync("MainPage");
        }
        [RelayCommand]
        private void FontSizeFinished()
        {
            EditMode = EeditMode.None;
        }

        [RelayCommand]
        private void ChnageFontAttributes()
        {
            EditMode = EeditMode.FontAttributes;         
        }

        [RelayCommand]
        private void AcceptAttributes()
        {
            EditMode = EeditMode.None;
        }


        #endregion
    }
}

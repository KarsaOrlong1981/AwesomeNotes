using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwesomeNotes.Model
{
    public class Note : ObservableObject
    {
        public string Id { get; set; }

        private string title;
        public string Title 
        { 
            get => title; 
            set => SetProperty(ref title, value, nameof(Title)); 
        }

        private string text;
        public string Text 
        {
            get => text; 
            set => SetProperty(ref text, value, nameof(Text)); 
        }
        private string fontFamily;
        public string FontFamily 
        { 
            get => fontFamily; 
            set => SetProperty(ref fontFamily, value, nameof(FontFamily)); 
        }
        public string Categorie { get; set; }

        private double fontSize;
        public double FontSize
        {
            get => fontSize;
            set => SetProperty(ref  fontSize, value, nameof(FontSize));
        }

        private TextDecorations textDeco;   
        public TextDecorations TextDeco
        {
            get => textDeco;
            set => SetProperty(ref textDeco, value, nameof(TextDeco));
        }

        private FontAttributes fontAttribute;
        public FontAttributes FontAttribute
        {
            get => fontAttribute;
            set => SetProperty(ref fontAttribute, value, nameof(FontAttribute));
        }

        private Color backgroundColor;
        public Color Background 
        { 
            get => backgroundColor; 
            set => SetProperty(ref backgroundColor, value, nameof(Background)); 
        }

        private Color textColor;
        public Color TextColor 
        { 
            get => textColor; 
            set => SetProperty(ref textColor, value, nameof(TextColor)); 
        }

        public ImageSource BackgroundImage { get; set; }

        public List<ImageSource> ImageSources { get; set; }

        public DateTime DateTime { get; set; }
      
    }
}

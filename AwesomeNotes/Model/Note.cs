using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Model
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Color Background { get; set; }
        public Color TextColor { get; set; }
        public ImageSource BackgroundImage { get; set; }
        public List<ImageSource> ImageSources { get; set; }
        public DateTime DateTime { get; set; }
    }
}

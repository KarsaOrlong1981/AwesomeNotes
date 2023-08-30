using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Helper
{
    public static class BackgroundHelper
    {
        public static Color CurrentBackGround { get; set;}
        public static Color CurrentTextColor { get; set;}   
        public static Color NoteBackGround { get; set;}
        public static Color NoteTextColor { get; set;}

        public static void SaveBackgroundColor(Color backColor)
        {
            Preferences.Default.Set("Background21", backColor.ToHex().ToString());
        }

        public static void SaveTextColor(Color textColor)
        {
            Preferences.Default.Set("TextColor21", textColor.ToHex().ToString());
        }

        public static Color GetBackgroundColor()
        {
            Color color = Colors.White;
            if (Preferences.Default.ContainsKey("Background21"))
            {
                var hex = Preferences.Default.Get("Background21", string.Empty);
                color = Color.FromArgb(hex);
            }
            return color;
        }

        public static Color GetTextColor()
        {
            Color color = Colors.Blue;
            if (Preferences.Default.ContainsKey("TextColor21"))
            {
                var hex = Preferences.Default.Get("TextColor21", string.Empty);
                color = Color.FromArgb(hex);
            }
            return color;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Helper
{
    public static class FontsHelper
    {
        public static List<String> FontAliasList = new List<String>();

        public static List<string> GetFontAliasList ()
        {
            InitFontAliasList();
            return FontAliasList;
        }

        private static void InitFontAliasList()
        {
            FontAliasList.Add("OpenSansRegular");
            FontAliasList.Add("OpenSansSemibold");
            FontAliasList.Add("IWantMy");
            FontAliasList.Add("BarbieDoll");
            FontAliasList.Add("Humayra");
            FontAliasList.Add("TypeRgb");
            FontAliasList.Add("Aqira");
            FontAliasList.Add("Harima");
            FontAliasList.Add("Hanking");
            FontAliasList.Add("Dino");
            FontAliasList.Add("Pamello");
            FontAliasList.Add("Rampwind");
            FontAliasList.Add("SuperHappy");
            FontAliasList.Add("Hagi");
            FontAliasList.Add("BakeryHolland");
            FontAliasList.Add("SpicyNachos");
            FontAliasList.Add("FunkyFoodieDoodie");
            FontAliasList.Add("SpicyHotdog");
            FontAliasList.Add("Robienz");
            FontAliasList.Add("Americandreams");
            FontAliasList.Add("Banetty");
            FontAliasList.Add("Fortieth");
            FontAliasList.Add("Home888");
            FontAliasList.Add("Shirlock");
            FontAliasList.Add("ShortimeSunday");
            FontAliasList.Add("Signspaintedscript");
            FontAliasList.Add("Badgline");
            FontAliasList.Add("Doknatle");
            FontAliasList.Add("Blanvad");
            FontAliasList.Add("ChorneilRegular");
            FontAliasList.Add("Travesty");
            FontAliasList.Add("MadfoolRegular");
            FontAliasList.Add("OnelySans");
            FontAliasList.Add("Malonet");
            FontAliasList.Add("NightScreamPersonalUse");
            FontAliasList.Add("ScaryNotesPersonalUse");
        }
    }
}

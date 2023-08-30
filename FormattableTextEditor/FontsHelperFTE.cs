using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichTextEditor
{
    public static class FontsHelperFTE
    {
        public static List<String> FontAliasList = new List<String>();

        public static List<string> GetFontAliasList ()
        {
            InitFontAliasList();
            return FontAliasList;
        }
        public static string GetCurrentFontString(string value)
        {
            var fonts = GetFontstrings();
            var font = "";  
            foreach (var f in fonts)
            {
                if (f.Value == value)
                {
                    font = f.Key;
                    break;
                }
            }

            return font;
        }

        private static Dictionary<string, string> GetFontstrings()
        {
            var fonts = new Dictionary<string, string>();

            fonts.Add("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.Add("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.Add("IWantMyTtr-ALV8p.ttf", "IWantMy");
            fonts.Add("BarbieDoll-p7Yqd.ttf", "BarbieDoll");
            fonts.Add("Humayra-3z4mp.ttf", "Humayra");
            fonts.Add("TypoRgbOutlinedemo-Ean9W.otf", "TypeRgb");
            fonts.Add("Aqira-Wyg0n.ttf", "Aqira");
            fonts.Add("Harima-X3od9.otf", "Harima");
            fonts.Add("Hanking-1GgZZ.otf", "Hanking");
            fonts.Add("Haidenisa-rgMdx.otf", "Haidenisa");
            fonts.Add("DinoRegular-X3pwg.ttf", "Dino");
            fonts.Add("PamelloGlenstar-GORZP.otf", "Pamello");
            fonts.Add("Rampwind-WygP9.otf", "Rampwind");
            fonts.Add("SuperHappyDemo-MVKBp.ttf", "SuperHappy");
            fonts.Add("Hagi-MVKOP.otf", "Hagi");
            fonts.Add("BakeryHolland-rgM8B.ttf", "BakeryHolland");
            fonts.Add("SpicyNachos-BWJqw.ttf", "SpicyNachos");
            fonts.Add("FunkyFoodieDoodie-DOlG3.ttf", "FunkyFoodieDoodie");
            fonts.Add("SpicyHotdog-gxVpE.ttf", "SpicyHotdog");
            fonts.Add("Robienz-8M94n.ttf", "Robienz");
            fonts.Add("AmericandreamsRegular-1Gg2v.otf", "Americandreams");
            fonts.Add("Banetty-lg1Kw.otf", "Banetty");
            fonts.Add("Fortieth-7BarD.ttf", "Fortieth");
            fonts.Add("Cleudia-JRYpj.otf", "Cleudia");
            fonts.Add("Home888-ALVRM.otf", "Home888");
            fonts.Add("Shirlock-rgMgy.otf", "Shirlock");
            fonts.Add("ShortimeSunday-9Ylx5.ttf", "ShortimeSunday");
            fonts.Add("Signspaintedscript-owLJB.ttf", "Signspaintedscript");
            fonts.Add("Badgline-gxKOq.otf", "Badgline");
            fonts.Add("Doknatle-d9YRE.otf", "Doknatle");
            fonts.Add("Blanvad-mLdwa.otf", "Blanvad");
            fonts.Add("ChorneilRegular-7BVJR.otf", "ChorneilRegular");
            fonts.Add("Travesty-K7XmZ.ttf", "Travesty");
            fonts.Add("MadfoolRegular-lgm2V.ttf", "MadfoolRegular");
            fonts.Add("OnelySans-7BVzl.ttf", "OnelySans");
            fonts.Add("Malonet-vmWYO.otf", "Malonet");
            fonts.Add("NightScreamPersonalUse-OV0xo.otf", "NightScreamPersonalUse");
            fonts.Add("ScaryNotesPersonalUse-ZVAxl.otf", "ScaryNotesPersonalUse");

            return fonts;
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

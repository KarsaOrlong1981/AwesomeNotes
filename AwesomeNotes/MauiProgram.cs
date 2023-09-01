using AwesomeNotes.Controls;
using AwesomeNotes.Services;
using CommunityToolkit.Maui;
using FormattableTextEditor;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Sharpnado.CollectionView;
using SkiaSharp.Views.Maui.Controls.Hosting;


namespace AwesomeNotes
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterServices()
                .UseSharpnadoCollectionView(loggerEnable: false)
                .UseMauiCommunityToolkit()
                .UseMauiCompatibility()
                .UseFormattableTextEditor()
                .ConfigureMauiHandlers(handlers =>
                {
#if __ANDROID__
                    handlers.AddCompatibilityRenderer(typeof(Entry), typeof(Droid.EntryRendererDroid));
#endif

                })
                .ConfigureFonts(fonts =>
                {
                    RegisterFonts(fonts);
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.UseSkiaSharp();
            return builder.Build();
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            //Services
            builder.Services.AddSingleton<ISaveService, SaveService> ();
            //Transients
            builder.Services.AddTransient<MainPage>();
            return builder;
        }

        private static void RegisterFonts(IFontCollection fonts)
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("IWantMyTtr-ALV8p.ttf", "IWantMy");
            fonts.AddFont("BarbieDoll-p7Yqd.ttf", "BarbieDoll");
            fonts.AddFont("Humayra-3z4mp.ttf", "Humayra");
            fonts.AddFont("TypoRgbOutlinedemo-Ean9W.otf", "TypeRgb");
            fonts.AddFont("Aqira-Wyg0n.ttf", "Aqira");
            fonts.AddFont("Harima-X3od9.otf", "Harima");
            fonts.AddFont("Hanking-1GgZZ.otf", "Hanking");
            fonts.AddFont("Haidenisa-rgMdx.otf", "Haidenisa");
            fonts.AddFont("DinoRegular-X3pwg.ttf", "Dino");
            fonts.AddFont("PamelloGlenstar-GORZP.otf", "Pamello");
            fonts.AddFont("Rampwind-WygP9.otf", "Rampwind");
            fonts.AddFont("SuperHappyDemo-MVKBp.ttf", "SuperHappy");
            fonts.AddFont("Hagi-MVKOP.otf", "Hagi");
            fonts.AddFont("BakeryHolland-rgM8B.ttf", "BakeryHolland");
            fonts.AddFont("SpicyNachos-BWJqw.ttf", "SpicyNachos");
            fonts.AddFont("FunkyFoodieDoodie-DOlG3.ttf", "FunkyFoodieDoodie");
            fonts.AddFont("SpicyHotdog-gxVpE.ttf", "SpicyHotdog");
            fonts.AddFont("Robienz-8M94n.ttf", "Robienz");
            fonts.AddFont("AmericandreamsRegular-1Gg2v.otf", "Americandreams");
            fonts.AddFont("Banetty-lg1Kw.otf", "Banetty");
            fonts.AddFont("Fortieth-7BarD.ttf", "Fortieth");
            fonts.AddFont("Cleudia-JRYpj.otf", "Cleudia");
            fonts.AddFont("Home888-ALVRM.otf", "Home888");
            fonts.AddFont("Shirlock-rgMgy.otf", "Shirlock");
            fonts.AddFont("ShortimeSunday-9Ylx5.ttf", "ShortimeSunday");
            fonts.AddFont("Signspaintedscript-owLJB.ttf", "Signspaintedscript");
            fonts.AddFont("Badgline-gxKOq.otf", "Badgline");
            fonts.AddFont("Doknatle-d9YRE.otf", "Doknatle");
            fonts.AddFont("Blanvad-mLdwa.otf", "Blanvad");
            fonts.AddFont("ChorneilRegular-7BVJR.otf", "ChorneilRegular");
            fonts.AddFont("Travesty-K7XmZ.ttf", "Travesty");
            fonts.AddFont("MadfoolRegular-lgm2V.ttf", "MadfoolRegular");
            fonts.AddFont("OnelySans-7BVzl.ttf", "OnelySans");
            fonts.AddFont("Malonet-vmWYO.otf", "Malonet");
            fonts.AddFont("NightScreamPersonalUse-OV0xo.otf", "NightScreamPersonalUse");
            fonts.AddFont("ScaryNotesPersonalUse-ZVAxl.otf", "ScaryNotesPersonalUse");
        }
    }
}
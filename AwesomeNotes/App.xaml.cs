namespace AwesomeNotes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Sharpnado.CollectionView.Initializer.Initialize(true, false);
            MainPage = new AppShell();
        }
    }
}
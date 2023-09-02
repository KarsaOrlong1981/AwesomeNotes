namespace AwesomeNotes
{
    public partial class App : AppProvider
    {
        public App (IServiceProvider provider) : base(provider)
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
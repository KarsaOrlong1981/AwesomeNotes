using AwesomeNotes.Navigation;

namespace AwesomeNotes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            ShellNavigation.RegisterRoutes();
            this.Navigated += AppShell_Navigated;
        }

        private void AppShell_Navigated(object sender, ShellNavigatedEventArgs e)
        {
            
        }
    }
}
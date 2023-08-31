using AwesomeNotes.Helper;
using AwesomeNotes.Navigation;
using AwesomeNotes.Services;

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

            //var provider = ServiceHelper.ServiceProvider;
            //if (CurrentState.Location.OriginalString == "//MainPage")
            //{
            //    provider.GetService<ISaveService>().InvokeCategoriesChangedEvent();
            //}
        }
    }
}
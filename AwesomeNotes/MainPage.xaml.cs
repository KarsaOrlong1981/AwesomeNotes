using AwesomeNotes.Helper;
using AwesomeNotes.ViewModel;

namespace AwesomeNotes
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(IServiceProvider provider)
        {
            InitializeComponent();
            
            //cv.ItemsSource = FontsHelper.GetFontAliasList();
            BindingContext = new MainViewModel(provider);
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            
        }
    }
}
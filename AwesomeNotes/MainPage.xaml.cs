using AwesomeNotes.Helper;
using AwesomeNotes.ViewModel;

namespace AwesomeNotes
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            
            //cv.ItemsSource = FontsHelper.GetFontAliasList();
            BindingContext = new MainViewModel();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            
        }
    }
}
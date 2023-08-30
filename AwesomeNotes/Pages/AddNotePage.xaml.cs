using AwesomeNotes.ViewModel;

namespace AwesomeNotes.Pages;

public partial class AddNotePage : ContentPage
{
	public AddNotePage()
	{
		InitializeComponent();
		BindingContext = new AddNoteViewModel();
	}
}

using AwesomeNotes.ViewModel;
using System.Text;

namespace AwesomeNotes.Pages;

public partial class EditNotePage : ContentPage
{
	private EditNoteViewModel _vm = new EditNoteViewModel();
	public EditNotePage()
	{
		InitializeComponent();
		BindingContext = _vm;
		
	}
   
}
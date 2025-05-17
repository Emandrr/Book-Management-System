using Zdor353505.UI.ViewModels;
namespace Zdor353505.UI.Pages;

public partial class BookDetails : ContentPage
{
	public BookDetails(BookDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
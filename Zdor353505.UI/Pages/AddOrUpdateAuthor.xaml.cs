using Zdor353505.UI.ViewModels;
namespace Zdor353505.UI.Pages;

public partial class AddOrUpdateAuthor : ContentPage
{
	public AddOrUpdateAuthor(AddOrUpdateAuthorViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
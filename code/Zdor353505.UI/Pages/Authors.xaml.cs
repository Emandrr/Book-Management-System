using Zdor353505.UI.ViewModels;
namespace Zdor353505.UI.Pages;

public partial class Authors : ContentPage
{
	public Authors(AuthorsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
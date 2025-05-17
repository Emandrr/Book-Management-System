using Zdor353505.UI.ViewModels;
namespace Zdor353505.UI.Pages;

public partial class AddOrUpdateBook : ContentPage
{
	public AddOrUpdateBook(AddOrUpdateBookViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}
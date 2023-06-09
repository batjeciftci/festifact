using festifact.client.ViewModels;

namespace festifact.client.Pages;

public partial class HomeDetailsPage : ContentPage
{

    public HomeDetailsPage(HomeDetailsViewModel viewModel)
	{
		InitializeComponent();

        this.BindingContext = viewModel;
    }
}

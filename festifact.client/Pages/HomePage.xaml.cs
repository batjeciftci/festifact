using festifact.client.ViewModels;
using festifact.models.Dtos.Festival;

namespace festifact.client.Pages;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _viewModel;

    public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
        this._viewModel = viewModel;
        this.BindingContext = viewModel;
    }
}

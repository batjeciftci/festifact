using festifact.client.ViewModels;

namespace festifact.client.Pages;

public partial class DanceFestivalPage : ContentPage
{
    private readonly DanceFestivalViewModel _viewModel;

    public DanceFestivalPage(DanceFestivalViewModel viewModel)
	{
		InitializeComponent();
        this._viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetFestivalsByCategory(3);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viewModel.Festivals.Clear();
    }
}

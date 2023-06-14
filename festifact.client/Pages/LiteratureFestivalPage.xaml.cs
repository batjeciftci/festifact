using festifact.client.ViewModels;

namespace festifact.client.Pages;

public partial class LiteratureFestivalPage : ContentPage
{
    private readonly LiteratureFestivalViewModel _viewModel;

    public LiteratureFestivalPage(LiteratureFestivalViewModel viewModel)
	{
		InitializeComponent();
        this._viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetFestivalsByCategory(4);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viewModel.Festivals.Clear();
    }
}

using festifact.client.ViewModels;

namespace festifact.client.Pages;

public partial class MusicFestivalPage : ContentPage
{
    private readonly MusicFestivalViewModel _musicFestivalViewModel;

    public MusicFestivalPage(MusicFestivalViewModel musicFestivalViewModel)
	{
		InitializeComponent();

        this._musicFestivalViewModel = musicFestivalViewModel;
        BindingContext = musicFestivalViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _musicFestivalViewModel.GetFestivalsByCategory(1);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _musicFestivalViewModel.Festivals.Clear();
    }
}

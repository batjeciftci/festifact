using festifact.client.ViewModels;
using festifact.models.Dtos.Festival;

namespace festifact.client.Pages;

[QueryProperty(nameof(FestivalDto), "festival")]
public partial class HomeDetailsPage : ContentPage
{

    private FestivalDto _festivalDto;
    public FestivalDto FestivalDto
    {
        get => _festivalDto;
        set
        {
            _festivalDto = value;
            OnPropertyChanged();
        }
    }

    public HomeDetailsPage(HomeDetailsViewModel viewModel)
	{
		InitializeComponent();

        this.BindingContext = this;
    }
}

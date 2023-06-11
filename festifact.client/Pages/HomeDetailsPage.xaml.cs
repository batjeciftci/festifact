using festifact.client.ViewModels;
using festifact.models.Dtos.CartItem;
using festifact.models.Dtos.Festival;

namespace festifact.client.Pages;

[QueryProperty(nameof(FestivalDto), "festival")]
public partial class HomeDetailsPage : ContentPage
{

    private FestivalDto _festivalDto;

    private readonly HomeDetailsViewModel _viewModel;

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

        this._viewModel = viewModel;

        this.BindingContext = this;
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await _viewModel.AddToCartClick(new CartItemToAddDto
        {
            ShoppingCartId = 1,
            FestivalId = this.FestivalDto.FestivalId,
            NumberOfTickets = 1,
            TotalAmount = 12
        });

        await Shell.Current.GoToAsync(nameof(ShoppingCartPage));
    }
}

using festifact.client.ViewModels;

namespace festifact.client.Pages;

public partial class ShoppingCartPage : ContentPage
{
    private readonly ShoppingCartViewModel _shoppingCartViewModel;

    public ShoppingCartPage(ShoppingCartViewModel shoppingCartViewModel)
	{
		InitializeComponent();

        this._shoppingCartViewModel = shoppingCartViewModel;
        this.BindingContext = shoppingCartViewModel;
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        string message = "Payment successful";

        await DisplayAlert("Payment message", message, "OK");

        await Shell.Current.GoToAsync(nameof(HomePage));
    }
}

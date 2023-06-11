using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using festifact.client.Services.Contracts;
using festifact.models.Dtos.CartItem;
using festifact.models.Dtos.Festival;

namespace festifact.client.ViewModels;

public class ShoppingCartViewModel : INotifyPropertyChanged
{
    private readonly IShoppingCartService _shoppingCartService;
    private ObservableCollection<CartItemDto> _cartItems;
    private int _numberOfTickets;
    private decimal _totalAmount;
    private string _title;

    public int NumberOfTickets
    {
        get => _numberOfTickets;
        set
        {
            _numberOfTickets = value;
            OnPropertyChanged();
        }
    }

    public decimal TotalAmount
    {
        get => _totalAmount;
        set
        {
            _totalAmount = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<CartItemDto> CartItems
    {
        get => _cartItems;
        set
        {
            _cartItems = value;
            OnPropertyChanged();
        }
    }

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    // Constructor
    public ShoppingCartViewModel(IShoppingCartService shoppingCartService)
	{
        this._shoppingCartService = shoppingCartService;
        this._cartItems = new();

        this._title = "CartItems";

        Task.Run(async () => await GetCartItems());
    }

    private async Task GetCartItems()
    {
        try
        {
            var cartItems = await _shoppingCartService.GetCartItems();

            CartItems.Clear();

            foreach (var item in cartItems)
            {
                CartItems.Add(item);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Festivals could not be retrieved, {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}


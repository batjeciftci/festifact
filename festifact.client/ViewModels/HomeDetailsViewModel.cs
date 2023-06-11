using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using festifact.client.Pages;
using festifact.client.Services.Contracts;
using festifact.models.Dtos.CartItem;
using festifact.models.Dtos.Festival;

namespace festifact.client.ViewModels;

[QueryProperty(nameof(FestivalDto), "festival")]
public class HomeDetailsViewModel : INotifyPropertyChanged
{
    private readonly IShoppingCartService _cartService;

    public int Id { get; set; }

    private FestivalDto _festivalDto;

    public FestivalDto FestivalDto
    {
        get => _festivalDto;
        set
        {
            if (_festivalDto != value)
            {
                _festivalDto = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;


    // CONSTRUCTOR
    public HomeDetailsViewModel(IShoppingCartService cartService)
    {
        this._cartService = cartService;
    }

    public async Task AddToCartClick(CartItemToAddDto cartItemToAddDto)
    {
        try
        {
            var result = await _cartService.AddCartItem(cartItemToAddDto);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
    }
}

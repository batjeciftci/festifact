using System;
using festifact.models.Dtos.CartItem;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using festifact.server.Services.Contracts;

namespace festifact.server.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _repository;

    public ShoppingCartService(IShoppingCartRepository repository)
	{
        this._repository = repository;
    }

    public async Task<IEnumerable<CartItem>> GetItems()
    {
        var cartItems = await _repository.GetItems();
        return cartItems;
    }

    public async Task<CartItem> GetItem(int id)
    {
        var cartItem = await _repository.GetItem(id);
        return cartItem;
    }

    // Add Business Logic Here!
    public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
    {
        var cartItem = await _repository.AddItem(cartItemToAddDto);
        return cartItem;
    }

    // Add Business Logic Here!
    public async Task<CartItem> UpdateItem(int id, CartItemNumberOfTicketsUpdateDto cartItemNumberOfTicketsUpdateDto)
    {
        var cartItem = await _repository.UpdateItem(id, cartItemNumberOfTicketsUpdateDto);
        return cartItem;
    }

    // Add Business Logic Here!
    public async Task<CartItem> DeleteItem(int id)
    {
        var cartItem = await _repository.DeleteItem(id);
        return cartItem;
    }

    // Add Business Logic Here!
    public async Task<IEnumerable<CartItem>> DeleteItems(int visitorId)
    {
        var cartItem = await _repository.DeleteItems(visitorId);
        return cartItem;
    }
}

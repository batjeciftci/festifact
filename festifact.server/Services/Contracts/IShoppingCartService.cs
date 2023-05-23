using System;
using festifact.models.Dtos.CartItem;
using festifact.server.Entities;

namespace festifact.server.Services.Contracts;

public interface IShoppingCartService
{
    Task<IEnumerable<CartItem>> GetItems(int visitorId);

    Task<CartItem> GetItem(int id);

    Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);

    Task<CartItem> UpdateItem(int id, CartItemNumberOfTicketsUpdateDto cartItemNumberOfTicketsUpdateDto);

    Task<IEnumerable<CartItem>> DeleteItems(int visitorId);

    Task<CartItem> DeleteItem(int id);
}

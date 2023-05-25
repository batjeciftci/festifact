using System;
using festifact.server.Entities;
using festifact.models.Dtos.CartItem;

namespace festifact.server.Repositories.Contracts;

public interface IShoppingCartRepository
{
    Task<IEnumerable<CartItem>> GetItems(int visitorId);

    Task<CartItem> GetItem(int id);

    Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);

    Task<CartItem> UpdateItem(int id, CartItemNumberOfTicketsUpdateDto cartItemNumberOfTicketsUpdateDto);

    Task<IEnumerable<CartItem>> DeleteItems(int visitorId);

    Task<CartItem> DeleteItem(int id);
}



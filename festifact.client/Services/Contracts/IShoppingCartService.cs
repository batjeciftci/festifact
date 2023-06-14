using System;
using festifact.models.Dtos.CartItem;

namespace festifact.client.Services.Contracts;

public interface IShoppingCartService
{
    Task<IEnumerable<CartItemDto>> GetCartItems();

    Task<CartItemDto> AddCartItem(CartItemToAddDto cartItemToAddDto);

    Task<CartItemDto> DeleteCartItem(int id);
}


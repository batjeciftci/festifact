using System;
using System.Diagnostics;
using festifact.models.Dtos.CartItem;
using festifact.server.Database;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace festifact.server.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly FestiFactDbContext _dbContext;

    public ShoppingCartRepository(FestiFactDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<CartItem>> GetItems()
    {
        var query = await (from shoppingCart in _dbContext.ShoppingCarts
                           join cartItem in _dbContext.CartItems
                           on shoppingCart.ShoppingCartId equals cartItem.ShoppingCartId
                           select new CartItem
                           {
                               CartItemId = cartItem.CartItemId,
                               NumberOfTickets = cartItem.NumberOfTickets,
                               TotalAmount = cartItem.TotalAmount,
                               FestivalId = cartItem.FestivalId,
                               ShoppingCartId = cartItem.ShoppingCartId
                           }).ToListAsync();
        return query;
    }

    public async Task<CartItem> GetItem(int id)
    {
        var cartItem = await _dbContext.CartItems.FindAsync(id);
        return cartItem;
    }

    public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
    {
        var cartItem = new CartItem
        {
            NumberOfTickets = cartItemToAddDto.NumberOfTickets,
            TotalAmount = cartItemToAddDto.TotalAmount,
            FestivalId = cartItemToAddDto.FestivalId,
            ShoppingCartId = cartItemToAddDto.ShoppingCartId
        };

        var result = await _dbContext.CartItems.AddAsync(cartItem);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<CartItem> UpdateItem(int id, CartItemNumberOfTicketsUpdateDto cartItemNumberOfTicketsUpdateDto)
    {
        var cartItem = await _dbContext.CartItems.FindAsync(id);

        if (cartItem != null)
        {
            cartItem.NumberOfTickets = cartItemNumberOfTicketsUpdateDto.NumberOfTickets;

            var result = _dbContext.CartItems.Update(cartItem);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        return null;
    }

    public async Task<CartItem> DeleteItem(int id)
    {
        var cartItem = await _dbContext.CartItems.FindAsync(id);

        if (cartItem is not null)
        {
            var result = _dbContext.CartItems.Remove(cartItem);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        return null;
    }

    public async Task<IEnumerable<CartItem>> DeleteItems(int visitorId)
    {
        var query = await (from shoppingCart in _dbContext.ShoppingCarts
                           join cartItem in _dbContext.CartItems
                           on shoppingCart.ShoppingCartId equals cartItem.ShoppingCartId
                           where shoppingCart.VisitorId == visitorId
                           select cartItem).ToListAsync();

        if (query.Any())
        {
            _dbContext.CartItems.RemoveRange(query);
            await _dbContext.SaveChangesAsync();
            return query;
        }
        Debug.WriteLine($"CartItems of visitor with id:{visitorId} could not be deleted!");
        return null;
    }
}

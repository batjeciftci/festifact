using System;

namespace festifact.models.Dtos.CartItem;

public class CartItemDto
{
    public int CartItemId { get; set; }

    public int NumberOfTickets { get; set; }

    public decimal TotalAmount { get; set; }

    public int FestivalId { get; set; }

    public int ShoppingCartId { get; set; }
}


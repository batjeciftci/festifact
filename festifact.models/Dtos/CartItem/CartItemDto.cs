using System;

namespace festifact.models.Dtos.CartItem;

public class CartItemDto
{
    public int CartItemId { get; set; }

    // 3
    public int NumberOfTickets { get; set; }

    public decimal TotalAmount { get; set; }

    // 2
    public int FestivalId { get; set; }

    // 1
    public int ShoppingCartId { get; set; }
}


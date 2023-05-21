using System;

namespace festifact.server.Entities;

public class CartItem
{
	public int CartItemId { get; set; }

	public int NumberOfTickets { get; set; }

	public decimal TotalAmount { get; set; }

	public int FestivalId { get; set; }

	public int ShoppingCartId { get; set; }
}



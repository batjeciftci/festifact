using System;

namespace festifact.server.Entities;

public class CartItem
{
	public int CartItemId { get; set; }

	public int NumberOfTickets { get; set; }

	// Property probably not needed. could be solved by defining a method that calculates the total amount.
	public decimal TotalAmount { get; set; }

	public int FestivalId { get; set; }

	public int ShoppingCartId { get; set; }
}



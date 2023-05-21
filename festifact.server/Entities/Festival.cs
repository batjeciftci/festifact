using System;
using System.ComponentModel.DataAnnotations;

namespace festifact.server.Entities;

public class Festival
{
	public int FestivalId { get; set; }

	[Required(ErrorMessage = "Title is required!")]
	public string? Title { get; set; }

	[StringLength(255)]
	public string? Description { get; set; }

	[Required(ErrorMessage = "Date is required!")]
	public DateOnly Date { get; set; }

	[Required]
	public string? BannerImageUrl { get; set; }

	public string? Genre { get; set; }

	[Required(ErrorMessage = "Age is required!")]
	public int Age { get; set; }

	public int NumberOfDays { get; set; }

	public string? Location { get; set; }

	public int Price { get; set; }

	[Required(ErrorMessage = "Capacity is required!")]
	public int Capacity { get; set; }

	public int ShowId { get; set; }

	public int FestivalCategoryId { get; set; }
}




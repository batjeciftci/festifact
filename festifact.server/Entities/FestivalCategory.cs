using System;
using System.ComponentModel.DataAnnotations;

namespace festifact.server.Entities;

public class FestivalCategory
{
	public int FestivalCategoryId { get; set; }

	[Required]
	public string? Name { get; set; }
}


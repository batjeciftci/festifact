using System;
using System.ComponentModel.DataAnnotations;

namespace festifact.server.Entities;

public class Show
{
	public int ShowId { get; set; }

	[Required(ErrorMessage = "Title is required!")]
	public string? Title { get; set; }

	[StringLength(255)]
	public string? Description { get; set; }

	public string? ImageUrl { get; set; }

	public DateTime StartTime { get; set; }

	public DateTime EndTime { get; set; }

	public int ArtistId { get; set; }

	public int FilmId { get; set; }
}


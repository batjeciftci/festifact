using System;
using System.ComponentModel.DataAnnotations;

namespace festifact.server.Entities;

public class Film
{
	public int FilmId { get; set; }

    [Required(ErrorMessage = "Title is required!")]
    public string? Title { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    [Required]
    public string? Director { get; set; }

    [Required]
    public int YearOfPublication { get; set; }

    public string? CountryOfOrigin { get; set; }
}



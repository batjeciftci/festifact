using System;
using System.ComponentModel.DataAnnotations;

namespace festifact.models.Dtos.Film;

public class FilmDto
{
    public int FilmId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Director { get; set; }

    public int YearOfPublication { get; set; }

    public string? CountryOfOrigin { get; set; }
}


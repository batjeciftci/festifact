using System;
using System.ComponentModel.DataAnnotations;

namespace festifact.models.Dtos.Artist;

public class ArtistDto
{
    public int ArtistId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? CountryOfOrigin { get; set; }

    public string? Genre { get; set; }
}


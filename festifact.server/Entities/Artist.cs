using System;
using System.ComponentModel.DataAnnotations;

namespace festifact.server.Entities;

public class Artist
{
    public int ArtistId { get; set; }

    [Required(ErrorMessage = "Name is required!")]
    public string? Name { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    public string? CountryOfOrigin { get; set; }

    public string? Genre { get; set; }
}

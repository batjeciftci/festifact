using System;

namespace festifact.models.Dtos.Show;

public class ShowDto
{
    public int ShowId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int ArtistId { get; set; }

    public int FilmId { get; set; }
}

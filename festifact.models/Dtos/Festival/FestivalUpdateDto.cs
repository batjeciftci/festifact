using System;

namespace festifact.models.Dtos.Festival;

public class FestivalUpdateDto
{
    public int FestivalId { get; set; }

    public DateTime Date { get; set; }

    public string? Location { get; set; }
}


using System;
using System.ComponentModel.DataAnnotations;

namespace festifact.models.Dtos;

public class FestivalUpdateDto
{
    public int FestivalId { get; set; }

    public DateTime Date { get; set; }

    public string? Location { get; set; }
}



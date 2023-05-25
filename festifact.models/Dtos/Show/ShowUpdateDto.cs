using System;
using System.ComponentModel.DataAnnotations;

namespace festifact.models.Dtos.Show;

public class ShowUpdateDto
{
    public int ShowId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}


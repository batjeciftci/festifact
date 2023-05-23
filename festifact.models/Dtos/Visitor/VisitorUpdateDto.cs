using System;

namespace festifact.models.Dtos;

public class VisitorUpdateDto
{
    public int VisitorId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Residence { get; set; }

    public string? Email { get; set; }

    public int Password { get; set; }
}


using System;
using System.ComponentModel.DataAnnotations;

namespace festifact.server.Entities;

public class Visitor
{
    public int VisitorId { get; set; }

    [Required(ErrorMessage = "Firstname is required!")]
    public string? Firstname { get; set; }

    [Required(ErrorMessage = "Lastname is required!")]
    public string? Lastname { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? Sex { get; set; }

    public string? Residence { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [MaxLength(20)]
    [DataType(DataType.Password)]
    public int Password { get; set; }
}



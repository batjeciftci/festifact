using System;

namespace festifact.models.Dtos.Festival;

public class FestivalToAddDto
{
    public int FestivalId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime Date { get; set; }

    public string? BannerImageUrl { get; set; }

    public string? Genre { get; set; }

    public int Age { get; set; }

    public int NumberOfDays { get; set; }

    public string? Location { get; set; }

    public int Price { get; set; }

    public int Capacity { get; set; }

    public int ShowId { get; set; }

    public int FestivalCategoryId { get; set; }
}


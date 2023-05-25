using System;
using festifact.models.Dtos.Festival;
using festifact.server.Entities;

namespace festifact.server.Services.Contracts;

public interface IFestivalService
{
    Task<IEnumerable<Festival>> GetFestivals();

    Task<IEnumerable<Festival>> GetFestivalsByCategory(int categoryId);

    Task<Festival> GetFestival(int id);

    Task<Festival> AddFestival(FestivalToAddDto festivalToAddDto);

    Task<Festival> UpdateFestival(int id, FestivalUpdateDto festivalUpdateDto);

    Task<Festival> DeleteFestival(int id);

    Task<IEnumerable<FestivalCategory>> GetFestivalCategories();
}


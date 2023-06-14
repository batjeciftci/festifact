using System;
using festifact.models.Dtos.Festival;

namespace festifact.client.Services.Contracts;

public interface IFestivalService
{
    Task<IEnumerable<FestivalDto>> GetFestivals();

    Task<FestivalDto> GetFestival(int id);

    Task<FestivalDto> AddFestival(FestivalToAddDto festivalToAddDto);

    Task<FestivalDto> AddFestival(FestivalDto festivalDto);

    Task<FestivalDto> UpdateFestival(FestivalUpdateDto festivalUpdateDto);

    Task<FestivalDto> DeleteFestival(int id);

    Task<IEnumerable<FestivalDto>> GetFestivalsByCategory(int categoryId);

    Task<IEnumerable<FestivalCategoryDto>> GetFestivalCategories();
}



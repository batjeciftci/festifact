using System;
using festifact.server.Entities;
using festifact.models.Dtos.Festival;

namespace festifact.server.Repositories.Contracts;

public interface IFestivalRepository
{
    Task<IEnumerable<Festival>> Get();

    Task<IEnumerable<Festival>> GetFestivalsByCategory(int categoryId);

    Task<Festival> Get(int id);

    Task<Festival> Add(FestivalToAddDto festivalToAddDto);

    Task<Festival> Update(int id, FestivalUpdateDto festivalUpdateDto);

    Task<Festival> Delete(int id);

    Task<IEnumerable<FestivalCategory>> GetFestivalCategories();
}


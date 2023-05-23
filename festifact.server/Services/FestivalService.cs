using System;
using festifact.models.Dtos.Festival;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using festifact.server.Services.Contracts;

namespace festifact.server.Services;

public class FestivalService : IFestivalService
{
    private readonly IFestivalRepository _repository;

    public FestivalService(IFestivalRepository repository)
	{
        this._repository = repository;
    }

    public async Task<IEnumerable<Festival>> GetFestivals()
    {
        var festivals = await _repository.Get();
        return festivals;
    }

    public async Task<Festival> GetFestival(int id)
    {
        var festival = await _repository.Get(id);
        return festival;
    }

    public async Task<IEnumerable<Festival>> GetFestivalsByCategory(int categoryId)
    {
        var festivalsByCategory = await _repository.GetFestivalsByCategory(categoryId);
        return festivalsByCategory;
    }

    // Add Business Logic Here!
    public async Task<Festival> AddFestival(FestivalToAddDto festivalToAddDto)
    {
        var aFestival = await _repository.Add(festivalToAddDto);
        return aFestival;
    }

    // Add Business Logic Here!
    public async Task<Festival> UpdateFestival(int id, FestivalUpdateDto festivalUpdateDto)
    {
        var aFestival = await _repository.Update(id, festivalUpdateDto);
        return aFestival;
    }

    // Add Business Logic Here!
    public async Task<Festival> DeleteFestival(int id)
    {
        var festival = await _repository.Delete(id);
        return festival;
    }

    public async Task<IEnumerable<FestivalCategory>> GetFestivalCategories()
    {
        var festivalCategories = await _repository.GetFestivalCategories();
        return festivalCategories;
    }

    public async Task<FestivalCategory> GetFestivalCategory(int id)
    {
        var festivalCategory = await _repository.GetFestivalCategory(id);
        return festivalCategory;
    }
}


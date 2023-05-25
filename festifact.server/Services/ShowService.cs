using System;
using festifact.models.Dtos.Show;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using festifact.server.Services.Contracts;

namespace festifact.server.Services;

public class ShowService : IShowService
{
    private readonly IShowRepository _repository;

    public ShowService(IShowRepository repository)
	{
        this._repository = repository;
    }

    public async Task<IEnumerable<Show>> GetShows()
    {
        var shows = await _repository.Get();
        return shows;
    }

    public async Task<Show> GetShow(int id)
    {
        var show = await _repository.Get(id);
        return show;
    }

    // Add Business Logic Here!
    public async Task<Show> AddShow(ShowToAddDto showToAddDto)
    {
        var show = await _repository.Add(showToAddDto);
        return show;
    }

    // Add Business Logic Here!
    public async Task<Show> UpdateShow(int id, ShowUpdateDto showUpdateDto)
    {
        var show = await _repository.Update(id, showUpdateDto);
        return show;
    }

    // Add Business Logic Here!
    public async Task<Show> DeleteShow(int id)
    {
        var show = await _repository.Delete(id);
        return show;
    }
}

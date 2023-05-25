using System;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using festifact.server.Services.Contracts;

namespace festifact.server.Services;

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _repository;

    public ArtistService(IArtistRepository repository)
	{
        this._repository = repository;
    }

    public async Task<IEnumerable<Artist>> GetArtists()
    {
        var artists = await _repository.Get();
        return artists;
    }

    public async Task<Artist> GetArtist(int id)
    {
        var artist = await _repository.Get(id);
        return artist;
    }
}


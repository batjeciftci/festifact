using System;
using festifact.server.Database;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace festifact.server.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly FestiFactDbContext _dbContext;

    public ArtistRepository(FestiFactDbContext dbContext)
	{
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<Artist>> Get()
    {
        var artists = await _dbContext.Artists.ToListAsync();
        return artists;
    }

    public async Task<Artist> Get(int id)
    {
        var artist = await _dbContext.Artists.FindAsync(id);
        return artist;
    }
}


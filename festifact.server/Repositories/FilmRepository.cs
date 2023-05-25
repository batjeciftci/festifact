using System;
using festifact.server.Database;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace festifact.server.Repositories;

public class FilmRepository : IFilmRepository
{
    private readonly FestiFactDbContext _dbContext;

    public FilmRepository(FestiFactDbContext dbContext)
	{
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<Film>> Get()
    {
        var films = await _dbContext.Films.ToListAsync();
        return films;
    }

    public async Task<Film> Get(int id)
    {
        var film = await _dbContext.Films.FindAsync(id);
        return film;
    }
}


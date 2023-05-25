using System;
using festifact.models.Dtos.Show;
using festifact.server.Database;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace festifact.server.Repositories;

public class ShowRepository : IShowRepository
{
    private readonly FestiFactDbContext _dbContext;

    public ShowRepository(FestiFactDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<Show>> Get()
    {
        var shows = await _dbContext.Shows.ToListAsync();
        return shows;
    }

    public async Task<Show> Get(int id)
    {
        var show = await _dbContext.Shows.FindAsync(id);
        return show;
    }

    public async Task<Show> Add(ShowToAddDto showToAddDto)
    {
        var show = new Show
        {
            Title = showToAddDto.Title,
            Description = showToAddDto.Description,
            ImageUrl = showToAddDto.ImageUrl,
            StartTime = showToAddDto.StartTime,
            EndTime = showToAddDto.EndTime,
            ArtistId = showToAddDto.ArtistId,
            FilmId = showToAddDto.FilmId
        };

        var result = await _dbContext.AddAsync(show);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Show> Update(int id, ShowUpdateDto showUpdateDto)
    {
        var show = await _dbContext.Shows.FindAsync(id);

        if (show is not null)
        {
            show.StartTime = showUpdateDto.StartTime;
            show.EndTime = showUpdateDto.EndTime;

            var result = _dbContext.Update(show);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        return default(Show);
    }

    public async Task<Show> Delete(int id)
    {
        var show = await _dbContext.Shows.FindAsync(id);

        if (show is not null)
        {
            _dbContext.Shows.Remove(show);
            await _dbContext.SaveChangesAsync();
            return show;
        }
        return default(Show);
    }
}

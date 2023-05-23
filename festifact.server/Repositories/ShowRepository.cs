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

    public async Task<Show> Add(ShowDto showDto)
    {
        var show = await (from aShow in _dbContext.Shows
                          where aShow.ShowId == showDto.ShowId
                          select new Show
                          {
                              Title = showDto.Title,
                              Description = showDto.Description,
                              ImageUrl = showDto.ImageUrl,
                              StartTime = showDto.StartTime,
                              EndTime = showDto.EndTime,
                              ArtistId = showDto.ArtistId,
                              FilmId = showDto.FilmId
                          }).SingleOrDefaultAsync();

        if (show is not null)
        {
            var result = await _dbContext.Shows.AddAsync(show);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        return null;
    }

    public async Task<Show> Update(int id, ShowUpdateDto showUpdateDto)
    {
        var show = await _dbContext.Shows.FindAsync(id);

        if (show is not null)
        {
            show.StartTime = showUpdateDto.StartTime;
            show.EndTime = showUpdateDto.EndTime;

            await _dbContext.SaveChangesAsync();
            return show;
        }
        return null;
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
        return null;
    }
}

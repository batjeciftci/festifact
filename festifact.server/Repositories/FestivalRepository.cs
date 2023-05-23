using System;
using festifact.models.Dtos;
using festifact.server.Database;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace festifact.server.Repositories;

public class FestivalRepository : IFestivalRepository
{
    private readonly FestiFactDbContext _dbContext;

    public FestivalRepository(FestiFactDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<Festival>> Get()
    {
        var festivals = await _dbContext.Festivals.ToListAsync();
        return festivals;
    }

    public async Task<IEnumerable<Festival>> GetFestivalsByCategory(int categoryId)
    {
        var festivals = await (from festival in _dbContext.Festivals
                               where festival.FestivalCategoryId == categoryId
                               select festival).ToListAsync();

        if (festivals.Any())
        {
            return festivals;
        }
        return Enumerable.Empty<Festival>();
    }

    public async Task<Festival> Get(int id)
    {
        var festival = await _dbContext.Festivals.FindAsync(id);
        return festival;
    }

    public async Task<Festival> Add(FestivalToAddDto festivalToAddDto)
    {
        var query = await (from festival in _dbContext.Festivals
                           where festival.FestivalId == festivalToAddDto.FestivalId
                           select new Festival
                           {
                               Title = festivalToAddDto.Title,
                               Description = festivalToAddDto.Description,
                               Date = festivalToAddDto.Date,
                               BannerImageUrl = festivalToAddDto.BannerImageUrl,
                               Genre = festivalToAddDto.Genre,
                               Age = festivalToAddDto.Age,
                               NumberOfDays = festivalToAddDto.NumberOfDays,
                               Location = festivalToAddDto.Location,
                               Price = festivalToAddDto.Price,
                               Capacity = festivalToAddDto.Capacity,
                               ShowId = festivalToAddDto.ShowId,
                               FestivalCategoryId = festivalToAddDto.FestivalCategoryId
                           }).SingleOrDefaultAsync();

        if (query is not null)
        {
            var result = await _dbContext.Festivals.AddAsync(query);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        return null;
    }

    public async Task<Festival> Update(int id, FestivalUpdateDto festivalUpdateDto)
    {
        var festival = await _dbContext.Festivals.FindAsync(id);

        if (festival is not null)
        {
            festival.Date = festivalUpdateDto.Date;
            festival.Location = festivalUpdateDto.Location;

            await _dbContext.SaveChangesAsync();
            return festival;
        }
        return null;
    }

    public async Task<Festival> Delete(int id)
    {
        var festival = await _dbContext.Festivals.FindAsync(id);
        return festival;
    }

    public async Task<IEnumerable<FestivalCategory>> GetFestivalCategories()
    {
        var festivalCategories = await _dbContext.FestivalCategories.ToListAsync();
        return festivalCategories;
    }

    public async Task<FestivalCategory> GetFestivalCategory(int id)
    {
        var festivalCategory = await _dbContext.FestivalCategories.FindAsync(id);
        return festivalCategory;
    }
}

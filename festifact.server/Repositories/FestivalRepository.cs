using System;
using festifact.models.Dtos.Festival;
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
        var festival = new Festival
        {
            FestivalId = festivalToAddDto.FestivalId,
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
        };

        var result = await _dbContext.Festivals.AddAsync(festival);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Festival> Update(int id, FestivalUpdateDto festivalUpdateDto)
    {
        var festival = await _dbContext.Festivals.FindAsync(id);

        if (festival is not null)
        {
            festival.Date = festivalUpdateDto.Date;
            festival.Location = festivalUpdateDto.Location;

            var result = _dbContext.Festivals.Update(festival);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        return default(Festival);
    }

    public async Task<Festival> Delete(int id)
    {
        var festival = await _dbContext.Festivals.FindAsync(id);

        if (festival != null)
        {
            var result = _dbContext.Festivals.Remove(festival);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        return null;
    }

    public async Task<IEnumerable<FestivalCategory>> GetFestivalCategories()
    {
        var festivalCategories = await _dbContext.FestivalCategories.ToListAsync();
        return festivalCategories;
    }
}

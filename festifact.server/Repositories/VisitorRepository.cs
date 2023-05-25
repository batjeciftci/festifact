using System;
using System.Diagnostics;
using festifact.models.Dtos.Visitor;
using festifact.server.Database;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace festifact.server.Repositories;

public class VisitorRepository : IVisitorRepository
{

    private readonly FestiFactDbContext _dbContext;

    public VisitorRepository(FestiFactDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<Visitor>> Get()
    {
        var visitors = await _dbContext.Visitors.ToListAsync();
        return visitors;
    }

    public async Task<Visitor> Get(int id)
    {
        var visitor = await _dbContext.Visitors.FindAsync(id);
        return visitor;
    }

    public async Task Add(VisitorToAddDto visitorToAddDto)
    {
        var visitor = new Visitor
        {
            VisitorId = visitorToAddDto.VisitorId,
            Firstname = visitorToAddDto.Firstname,
            Lastname = visitorToAddDto.Lastname,
            DateOfBirth = visitorToAddDto.DateOfBirth,
            Sex = visitorToAddDto.Sex,
            Residence = visitorToAddDto.Residence,
            Email = visitorToAddDto.Email,
            Password = visitorToAddDto.Password
        };

        var result = await _dbContext.Visitors.AddAsync(visitor);
        await _dbContext.SaveChangesAsync();
    }


    public async Task Update(int id, VisitorUpdateDto visitorUpdateDto)
    {
        var visitor = await _dbContext.Visitors.FindAsync(id);

        if (visitor is not null)
        {
            visitor.Firstname = visitorUpdateDto.Firstname;
            visitor.Lastname = visitorUpdateDto.Lastname;
            visitor.Residence = visitorUpdateDto.Residence;
            visitor.Email = visitorUpdateDto.Email;
            visitor.Password = visitorUpdateDto.Password;

            _dbContext.Update(visitor);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var visitor = await _dbContext.Visitors.FindAsync(id);

        if (visitor != null)
        {
            _dbContext.Visitors.Remove(visitor);
            await _dbContext.SaveChangesAsync();
        }
    }
}

using System;
using festifact.models.Dtos;
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
        var visitor = await (from aVisitor in _dbContext.Visitors
                             where aVisitor.VisitorId == visitorToAddDto.VisitorId
                             select new Visitor
                             {
                                 Firstname = visitorToAddDto.Firstname,
                                 Lastname = visitorToAddDto.Lastname,
                                 DateOfBirth = visitorToAddDto.DateOfBirth,
                                 Sex = visitorToAddDto.Sex,
                                 Residence = visitorToAddDto.Residence,
                                 Email = visitorToAddDto.Email,
                                 Password = visitorToAddDto.Password
                             }).SingleOrDefaultAsync(); // Execute query, retrieve single row.

        if (visitor is not null)
        {
            var result = await _dbContext.Visitors.AddAsync(visitor);
            await _dbContext.SaveChangesAsync();
        }
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

            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var visitor = await _dbContext.Visitors.FindAsync(id);

        if (visitor is not null)
        {
            _dbContext.Visitors.Remove(visitor);
            await _dbContext.SaveChangesAsync();
        }
    }
}

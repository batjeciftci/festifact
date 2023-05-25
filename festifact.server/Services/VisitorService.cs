using System;
using festifact.models.Dtos.Visitor;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using festifact.server.Services.Contracts;

namespace festifact.server.Services;

public class VisitorService : IVisitorService
{
    private readonly IVisitorRepository _repository;

    public VisitorService(IVisitorRepository repository)
	{
        this._repository = repository;
    }

    public async Task<IEnumerable<Visitor>> GetVisitors()
    {
        var visitors = await _repository.Get();
        return visitors;
    }

    public async Task<Visitor> GetVisitor(int id)
    {
        var visitor = await _repository.Get(id);
        return visitor;
    }

    // Add Business Logic Here!
    public async Task AddVisitor(VisitorToAddDto visitorToAddDto)
    {
        await _repository.Add(visitorToAddDto);
    }

    // Add Business Logic Here!
    public async Task UpdateVisitor(int id, VisitorUpdateDto visitorUpdateDto)
    {
        await _repository.Update(id, visitorUpdateDto);
    }

    // Add Business Logic Here!
    public async Task DeleteVisitor(int id)
    {
        await _repository.Delete(id);
    }
}


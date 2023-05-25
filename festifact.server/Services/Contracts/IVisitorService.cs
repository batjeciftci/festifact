using System;
using festifact.models.Dtos.Visitor;
using festifact.server.Entities;

namespace festifact.server.Services.Contracts;

public interface IVisitorService
{
    Task<IEnumerable<Visitor>> GetVisitors();

    Task<Visitor> GetVisitor(int id);

    Task AddVisitor(VisitorToAddDto visitorToAddDto);

    Task UpdateVisitor(int id, VisitorUpdateDto visitorUpdateDto);

    Task DeleteVisitor(int id);
}


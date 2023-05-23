using System;
using festifact.models.Dtos;
using festifact.server.Entities;

namespace festifact.server.Repositories.Contracts;

public interface IVisitorRepository
{
    Task<IEnumerable<Visitor>> Get();

    Task<Visitor> Get(int id);

    Task Add(VisitorToAddDto visitorToAddDto);

    Task Update(int id, VisitorUpdateDto visitorUpdateDto);

    Task Delete(int id);
}

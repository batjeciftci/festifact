using System;
using festifact.models.Dtos.Visitor;

namespace festifact.client.Services.Contracts;

public interface IVisitorService
{
    Task<IEnumerable<VisitorDto>> GetVisitors();

    Task<VisitorDto> GetVisitor(int id);

    Task<VisitorDto> AddVisitor(VisitorToAddDto visitorToAdd);

    Task<VisitorDto> UpdateVisitor(VisitorUpdateDto visitorUpdateDto);

    Task<VisitorDto> DeleteVisitor(int id);
}



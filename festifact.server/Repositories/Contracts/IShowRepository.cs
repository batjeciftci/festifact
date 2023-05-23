using System;
using festifact.models.Dtos;
using festifact.models.Dtos.Show;
using festifact.server.Entities;

namespace festifact.server.Repositories.Contracts;

public interface IShowRepository
{
    Task<IEnumerable<Show>> Get();

    Task<Show> Get(int id);

    Task<Show> Add(ShowDto showDto);

    Task<Show> Update(int id, ShowUpdateDto showUpdateDto);

    Task<Show> Delete(int id);
}


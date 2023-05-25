using System;
using festifact.server.Entities;

namespace festifact.server.Repositories.Contracts;

public interface IFilmRepository
{
    Task<IEnumerable<Film>> Get();

    Task<Film> Get(int id);
}


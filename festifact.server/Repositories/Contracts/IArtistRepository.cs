using System;
using festifact.server.Entities;

namespace festifact.server.Repositories.Contracts;

public interface IArtistRepository
{
    Task<IEnumerable<Artist>> Get();

    Task<Artist> Get(int id);
}


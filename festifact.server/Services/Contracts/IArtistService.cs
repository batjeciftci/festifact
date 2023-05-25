using System;
using festifact.server.Entities;

namespace festifact.server.Services.Contracts;

public interface IArtistService
{
    Task<IEnumerable<Artist>> GetArtists();

    Task<Artist> GetArtist(int id);
}



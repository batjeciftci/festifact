using System;
using festifact.server.Entities;

namespace festifact.server.Services.Contracts;

public interface IFilmService
{
    Task<IEnumerable<Film>> GetFilms();

    Task<Film> GetFilm(int id);
}


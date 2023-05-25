using System;
using festifact.server.Entities;
using festifact.server.Repositories.Contracts;
using festifact.server.Services.Contracts;

namespace festifact.server.Services;

public class FilmService : IFilmService
{
    private readonly IFilmRepository _repository;

    public FilmService(IFilmRepository repository)
    {
        this._repository = repository;
    }

    public async Task<IEnumerable<Film>> GetFilms()
    {
        var films = await _repository.Get();
        return films;
    }

    public async Task<Film> GetFilm(int id)
    {
        var film = await _repository.Get(id);
        return film;
    }
}


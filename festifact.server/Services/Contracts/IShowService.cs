using System;
using festifact.models.Dtos.Show;
using festifact.server.Entities;

namespace festifact.server.Services.Contracts;

public interface IShowService
{
    Task<IEnumerable<Show>> GetShows();

    Task<Show> GetShow(int id);

    Task<Show> AddShow(ShowToAddDto showToAddDto);

    Task<Show> UpdateShow(int id, ShowUpdateDto showUpdateDto);

    Task<Show> DeleteShow(int id);
}

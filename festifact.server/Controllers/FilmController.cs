using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using festifact.models.Dtos.Film;
using festifact.server.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using festifact.server.Helpers;

namespace festifact.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            this._filmService = filmService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmDto>>> GetFilms()
        {
            try
            {
                var films = await _filmService.GetFilms();

                if (films is null)
                {
                    return NotFound();
                }
                var filmDto = films.ConvertToDto();

                return Ok(filmDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmDto>> GetFilm(int id)
        {
            try
            {
                var film = await _filmService.GetFilm(id);

                if (film == null)
                {
                    return NotFound();
                }
                var filmDto = film.ConvertToDto();

                return Ok(filmDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
            }
        }
    }
}

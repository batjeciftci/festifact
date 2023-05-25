using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using festifact.models.Dtos.Artist;
using festifact.models.Dtos.Film;
using festifact.server.Services;
using festifact.server.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using festifact.server.Helpers;

namespace festifact.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            this._artistService = artistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDto>>> GetFilms()
        {
            try
            {
                var artists = await _artistService.GetArtists();

                if (artists is null)
                {
                    return NotFound();
                }
                var artistDto = artists.ConvertToDto();

                return Ok(artistDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDto>> GetArtist(int id)
        {
            try
            {
                var artist = await _artistService.GetArtist(id);

                if (artist is null)
                {
                    return NotFound();
                }
                var artistDto = artist.ConvertToDto();

                return Ok(artistDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
            }
        }


    }
}

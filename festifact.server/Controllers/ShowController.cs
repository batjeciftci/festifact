using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using festifact.models.Dtos.Show;
using festifact.server.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using festifact.server.Helpers;

namespace festifact.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            this._showService = showService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowDto>>> GetShows()
        {
            try
            {
                var shows = await _showService.GetShows();

                if (shows is null)
                {
                    Debug.WriteLine("Shows could not be retrieved from the database!");
                    return NotFound();
                }
                var showDto = shows.ConvertToDto();

                return Ok(showDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowDto>> GetShow(int id)
        {
            try
            {
                var show = await _showService.GetShow(id);

                if (show is null)
                {
                    Debug.WriteLine($"Show with Id:{id} is not found within the database!");
                    return NotFound();
                }
                var showDto = show.ConvertToDto();

                return Ok(showDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ShowToAddDto>> AddShow([FromBody] ShowToAddDto showToAddDto)
        {
            try
            {
                if (showToAddDto == null)
                {
                    return BadRequest();
                }
                await _showService.AddShow(showToAddDto);

                return CreatedAtAction(nameof(GetShow), new { id = showToAddDto.ShowId }, showToAddDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ShowUpdateDto>> UpdateShow(int id, [FromBody] ShowUpdateDto showUpdateDto)
        {
            try
            {
                if (id == 0 || showUpdateDto == null)
                {
                    return BadRequest();
                }
                var show = await _showService.UpdateShow(id, showUpdateDto);
                return Ok(show);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ShowDto>> DeleteShow(int id)
        {
            try
            {
                await _showService.DeleteShow(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

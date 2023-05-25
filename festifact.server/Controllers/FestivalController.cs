using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using festifact.models.Dtos.Festival;
using festifact.server.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using festifact.server.Helpers;

namespace festifact.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalController : ControllerBase
    {
        private readonly IFestivalService _festivalService;

        public FestivalController(IFestivalService festivalService)
        {
            this._festivalService = festivalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FestivalDto>>> GetFestivals()
        {
            try
            {
                var festivals = await _festivalService.GetFestivals();

                if (festivals == null)
                {
                    return NotFound();
                }
                var festivalDto = festivals.ConvertToDto();
                return Ok(festivalDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FestivalDto>> GetFestival(int id)
        {
            try
            {
                var festival = await _festivalService.GetFestival(id);

                if (festival is null)
                {
                    return NotFound();
                }
                var festivalDto = festival.ConvertToDto();

                return Ok(festivalDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<FestivalToAddDto>> AddFestival([FromBody] FestivalToAddDto festivalToAddDto)
        {
            try
            {
                if (festivalToAddDto is null)
                {
                    return BadRequest();
                }
                await _festivalService.AddFestival(festivalToAddDto);

                return CreatedAtAction(nameof(GetFestival), new { id = festivalToAddDto.FestivalId }, festivalToAddDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<FestivalUpdateDto>> UpdateFestival(int id, [FromBody] FestivalUpdateDto festivalUpdateDto)
        {
            try
            {
                if (id == 0 || festivalUpdateDto == null)
                {
                    return BadRequest();
                }
                var result = await _festivalService.UpdateFestival(id, festivalUpdateDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FestivalDto>> DeleteFestival(int id)
        {
            try
            {
                await _festivalService.DeleteFestival(id);
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("{categoryId}/GetFestivalsByCategory")]
        public async Task<ActionResult<IEnumerable<FestivalDto>>> GetFestivalsByCategory(int categoryId)
        {
            try
            {
                var festivalsByCategory = await _festivalService.GetFestivalsByCategory(categoryId);

                if (festivalsByCategory == null)
                {
                    return NotFound();
                }
                // Note that: ConvertDto instead of ConvertToDto.
                var festivalDto = festivalsByCategory.ConvertDto();

                return Ok(festivalDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route(nameof(GetFestivalCategories))]
        public async Task<ActionResult<IEnumerable<FestivalCategoryDto>>> GetFestivalCategories()
        {
            try
            {
                var festivalCategories = await _festivalService.GetFestivalCategories();

                if (festivalCategories is null)
                {
                    return NotFound();
                }
                var festivalCategoryDto = festivalCategories.ConvertToDto();

                return Ok(festivalCategoryDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

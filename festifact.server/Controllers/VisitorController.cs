using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using festifact.models.Dtos.Visitor;
using festifact.server.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using festifact.server.Helpers;
using System.Diagnostics;

namespace festifact.server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitorController : ControllerBase
{
    private readonly IVisitorService _visitorService;

    public VisitorController(IVisitorService visitorService, ILogger<VisitorController> logger)
    {
        this._visitorService = visitorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VisitorDto>>> GetVisitors()
    {
        try
        {
            var response = await _visitorService.GetVisitors();

            if (response is null)
            {
                return NotFound();
            }
            var visitorDto = response.ConvertToDto();

            return Ok(visitorDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VisitorDto>> GetVisitor(int id)
    {
        try
        {
            var response = await _visitorService.GetVisitor(id);

            if (response is null)
            {
                return NotFound();
            }
            var visitorDto = response.ConvertToDto();

            return Ok(visitorDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddVisitor([FromBody] VisitorToAddDto visitorToAddDto)
    {
        try
        {
            if (visitorToAddDto is null)
            {
                return BadRequest();
            }
            else
            {
                await _visitorService.AddVisitor(visitorToAddDto);

                return CreatedAtAction(nameof(GetVisitor), new { id = visitorToAddDto.VisitorId }, visitorToAddDto);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateVisitor(int id, [FromBody] VisitorUpdateDto visitorUpdateDto)
    {
        try
        {
            if (id == 0 || visitorUpdateDto == null)
            {
                return BadRequest();
            }
            await _visitorService.UpdateVisitor(id, visitorUpdateDto);
            return Ok(visitorUpdateDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteVisitor(int id)
    {
        try
        {
            await _visitorService.DeleteVisitor(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

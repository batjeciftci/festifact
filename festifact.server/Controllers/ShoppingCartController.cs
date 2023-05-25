using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using festifact.models.Dtos.CartItem;
using festifact.server.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using festifact.server.Helpers;
namespace festifact.server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        this._shoppingCartService = shoppingCartService;
    }

    [HttpGet]
    [Route("{visitorId}/GetItems")]
    public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int visitorId)
    {
        try
        {
            var items = await _shoppingCartService.GetItems(visitorId);

            if (items == null)
            {
                return NotFound();
            }
            var cartItemDto = items.ConvertToDto();

            return Ok(cartItemDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error. Check Database (connection)!");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CartItemDto>> GetItem(int id)
    {
        try
        {
            var item = await _shoppingCartService.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }
            var cartItemDto = item.ConvertToDto();

            return Ok(cartItemDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CartItemDto>> AddItem([FromBody] CartItemToAddDto cartItemToAdd)
    {
        try
        {
            if (cartItemToAdd is null)
            {
                return BadRequest();
            }
            var result = await _shoppingCartService.AddItem(cartItemToAdd);

            return CreatedAtAction(nameof(GetItem), new { id = result.CartItemId }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<CartItemDto>> UpdateItem(int id, [FromBody] CartItemNumberOfTicketsUpdateDto cartItemNumberOfTicketsUpdateDto)
    {
        try
        {
            if (id == 0 || cartItemNumberOfTicketsUpdateDto == null)
            {
                return BadRequest();
            }
            var result = await _shoppingCartService.UpdateItem(id, cartItemNumberOfTicketsUpdateDto);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CartItemDto>> DeleteItem(int id)
    {
        try
        {
            var item = await _shoppingCartService.DeleteItem(id);

            if (item is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{visitorId}/DeleteItems")]
    public async Task<ActionResult<IEnumerable<CartItemDto>>> DeleteItems(int visitorId)
    {
        try
        {
            var cartItems = await _shoppingCartService.DeleteItems(visitorId);

            if (cartItems == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

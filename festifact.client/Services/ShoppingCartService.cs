using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using festifact.client.Services.Contracts;
using festifact.models.Dtos.CartItem;


namespace festifact.client.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly string _baseAddress;
    private readonly HttpClient _httpClient;
    private JsonSerializerOptions _jsonSerializerOptions;


    public ShoppingCartService()
    {
        this._baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5038" : "http://localhost:5038";
        this._httpClient = new HttpClient() { BaseAddress = new Uri($"{_baseAddress}") };
        this._jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    public async Task<IEnumerable<CartItemDto>> GetCartItems()
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/ShoppingCart");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<CartItemDto>().ToList();
                }
                return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
            }
        }
        catch (Exception)
        {
            throw;
        } 
    }


    public async Task<CartItemDto> AddCartItem(CartItemToAddDto cartItemToAddDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync<CartItemToAddDto>("api/ShoppingCart", cartItemToAddDto);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(CartItemDto);
                }

                return await response.Content.ReadFromJsonAsync<CartItemDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status:{response.StatusCode} Message -{message}");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CartItemDto> DeleteCartItem(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/ShoppingCart/{id}");

            if (response.IsSuccessStatusCode)
            {
                // if successful, return CartItemDto object to the calling client.
                return await response.Content.ReadFromJsonAsync<CartItemDto>();
            }
            // if not successful, return null! de code hieronder betekent return null.
            return default(CartItemDto);
        }
        catch (Exception)
        {
            throw;
        }
    }
}


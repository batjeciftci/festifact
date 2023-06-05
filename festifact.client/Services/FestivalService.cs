using System;
using System.Net.Http.Json;
using System.Text.Json;
using festifact.client.Services.Contracts;
using festifact.models.Dtos.Festival;

namespace festifact.client.Services;

public class FestivalService : IFestivalService
{
    private readonly string _baseAddress;
    private readonly HttpClient _httpClient;
    private JsonSerializerOptions _jsonSerializerOptions;

    public FestivalService(HttpClient httpClient)
    {
        this._baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5038" : "http://localhost:5038";
        this._httpClient = httpClient;
        this._httpClient.BaseAddress = new Uri($"{_baseAddress}");
        this._jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    public Task<IEnumerable<FestivalDto>> GetFestivals()
    {
        throw new NotImplementedException();
    }

    public Task<FestivalDto> GetFestival(int id)
    {
        throw new NotImplementedException();
    }

    public Task<FestivalDto> AddFestival(FestivalToAddDto festivalToAddDto)
    {
        throw new NotImplementedException();
    }

    public Task<FestivalDto> UpdateFestival(FestivalUpdateDto festivalUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<FestivalDto> DeleteFestival(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FestivalDto>> GetFestivalsByCategory(int categoryId)
    {
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"/api/festival/{categoryId}/GetFestivalsByCategory");

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<FestivalDto>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<FestivalDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code:{response.StatusCode} Message:{message}");
            }
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Network Error: {ex.Message}");
        }
    }

    public Task<IEnumerable<FestivalCategoryDto>> GetFestivalCategories()
    {
        throw new NotImplementedException();
    }
}


using System;
using System.Diagnostics;
using System.Net.Http;
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

    public FestivalService()
    {
        this._baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5038" : "http://localhost:5038";
        this._httpClient = new HttpClient() { BaseAddress = new Uri($"{_baseAddress}") };
        this._jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    public async Task<IEnumerable<FestivalDto>> GetFestivals()
    {
        try
        {
            var responseMessage = await _httpClient.GetAsync("/api/festival");

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseBody = await responseMessage.Content.ReadAsStringAsync();

                var responseToJson = JsonSerializer.Deserialize<IEnumerable<FestivalDto>>(responseBody, _jsonSerializerOptions);

                return responseToJson;
            }
            responseMessage.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Network Error: {ex.Message}");
        }
        return Enumerable.Empty<FestivalDto>();
    }

    public async Task<FestivalDto> GetFestival(int id)
    {
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"/api/festival/{id}");

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                var responseToJson = JsonSerializer.Deserialize<FestivalDto>(responseBody, _jsonSerializerOptions);

                return responseToJson;
            }
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Network Error: {ex.Message}");
        }
        return null;
    }

    public async Task<FestivalDto> AddFestival(FestivalToAddDto festivalToAddDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync<FestivalToAddDto>("/api/festival", festivalToAddDto);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(FestivalDto);
                }
                return await response.Content.ReadFromJsonAsync<FestivalDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status:{response.StatusCode} Message:{message}");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Add new festival with id:{festivalToAddDto.FestivalId} failed!, {ex.Message}");
            throw;
        }
    }

    public async Task<FestivalDto> AddFestival(FestivalDto festivalDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync<FestivalDto>("/api/festival", festivalDto);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(FestivalDto);
                }
                return await response.Content.ReadFromJsonAsync<FestivalDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status:{response.StatusCode} Message:{message}");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Add new festival with id:{festivalDto.FestivalId} failed!, {ex.Message}");
            throw;
        }
    }

    public async Task<FestivalDto> UpdateFestival(FestivalUpdateDto festivalUpdateDto)
    {
        try
        {
            var festivalToJson = JsonSerializer.Serialize(festivalUpdateDto);

            var content = new StringContent(festivalToJson, System.Text.Encoding.UTF8, "application/json-patch+json");

            var response = await _httpClient.PatchAsync($"/api/festival/{festivalUpdateDto.FestivalId}", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<FestivalDto>();
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Update festival with id:{festivalUpdateDto.FestivalId} failed!, {ex.Message}");
            throw;
        }
    }

    public async Task<FestivalDto> DeleteFestival(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"/api/festival/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<FestivalDto>();
            }
            return default(FestivalDto);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Remove festival with id:{id} failed!, {ex.Message}");
            throw;
        }
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

    public async Task<IEnumerable<FestivalCategoryDto>> GetFestivalCategories()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/festival/GetFestivalCategories");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<FestivalCategoryDto>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<FestivalCategoryDto>>();
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
}


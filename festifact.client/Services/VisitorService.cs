using System;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using festifact.client.Services.Contracts;
using festifact.models.Dtos.Visitor;
using festifact.models.Dtos.Festival;
using System.Diagnostics;

namespace festifact.client.Services;

public class VisitorService : IVisitorService
{
    private readonly string _baseAddress;
    private HttpClient _HttpClient;
    private JsonSerializerOptions _jsonSerializerOptions;

    public VisitorService()
	{
        this._baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5038" : "http://localhost:5038";
        this._HttpClient = new HttpClient() { BaseAddress = new Uri($"{_baseAddress}") };
        this._jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    public async Task<IEnumerable<VisitorDto>> GetVisitors()
    {
        try
        {
            var responseMessage = await _HttpClient.GetAsync("/api/visitor");

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseBody = await responseMessage.Content.ReadAsStringAsync();

                var responseToJson = JsonSerializer.Deserialize<IEnumerable<VisitorDto>>(responseBody, _jsonSerializerOptions);

                return responseToJson;
            }
            responseMessage.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Network Error: {ex.Message}");
        }
        return Enumerable.Empty<VisitorDto>();
    }

    public async Task<VisitorDto> GetVisitor(int id)
    {
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"/api/visitor/{id}");

            HttpResponseMessage response = await _HttpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                var responseToJson = JsonSerializer.Deserialize<VisitorDto>(responseBody, _jsonSerializerOptions);

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

    public async Task<VisitorDto> AddVisitor(VisitorToAddDto visitorToAdd)
    {
        try
        {
            var response = await _HttpClient.PostAsJsonAsync<VisitorToAddDto>("/api/visitor", visitorToAdd);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(VisitorDto);
                }
                return await response.Content.ReadFromJsonAsync<VisitorDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status:{response.StatusCode} Message:{message}");
            }
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Network Error: {ex.Message}");
        }
    }

    public async Task<VisitorDto> UpdateVisitor(VisitorUpdateDto visitorUpdateDto)
    {
        try
        {
            var visitorToJson = JsonSerializer.Serialize(visitorUpdateDto);

            var content = new StringContent(visitorToJson, System.Text.Encoding.UTF8, "application/json-patch+json");

            var response = await _HttpClient.PatchAsync($"/api/visitor/{visitorUpdateDto.VisitorId}", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<VisitorDto>();
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Update visitor with id:{visitorUpdateDto.VisitorId} failed!, {ex.Message}");
            throw;
        }
    }

    public async Task<VisitorDto> DeleteVisitor(int id)
    {
        try
        {
            var response = await _HttpClient.DeleteAsync($"/api/visitor/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<VisitorDto>();
            }
            return default(VisitorDto);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Remove visitor with id:{id} failed!, {ex.Message}");
            throw;
        }
    }
}

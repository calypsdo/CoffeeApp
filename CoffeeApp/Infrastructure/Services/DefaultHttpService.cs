using System.Text.Json;

namespace CoffeeApp.Infrastructure.Services;
public class DefaultHttpService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public DefaultHttpService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
    {
        _httpClient = httpClient;
        _jsonOptions = jsonOptions;
    }

    public async Task<T> GetAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(content, _jsonOptions)!;
        }

        throw new HttpRequestException($"API returned status code {response.StatusCode}");
    }
}

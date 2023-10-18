using System.Text.Json;
using DigitalDungeon.Models;

namespace DigitalDungeon.Data;
public class GameApiService
{
    private HttpClient _httpClient;
    private string _apiKey;

    public GameApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["GamesApiKey"];
    }

    public async Task<IEnumerable<Game>> GetGamesFromApi()
    {
        var externalApiUrl = $"https://api.rawg.io/api/games?key={_apiKey}";

        var response = await _httpClient.GetAsync(externalApiUrl);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var games = JsonSerializer.Deserialize<IEnumerable<Game>>(content);
            return games;
        }
        else
        {
            return null;
        }
    }
}
using Entities.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CardGame.Ui.Services;

public class RequestService : IRequestService
{

    private readonly HttpClient _httpClient;
    public RequestService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<IEnumerable<CardHistory>> GetAllCardHistoriesAsync()
    {
        var respons = await _httpClient.GetFromJsonAsync<IEnumerable<CardHistory>>("card");
        return respons!;
    }
    public async Task<List<Card>> GetNewDeck()
    {
        var respons = await _httpClient.GetFromJsonAsync<List<Card>>("card/deck");
        return respons!;
    }
  
}

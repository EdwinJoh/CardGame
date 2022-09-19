using Entities.Models;
using Shared.DataTransferObjects;
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
    public async Task SaveHand(string hand) 
    {
        HandForCreationDto handToSave = new HandForCreationDto();

        List<string> allCardsStored;
        allCardsStored = hand.Split(",").ToList();

        string[] cardsSplited = allCardsStored.ToArray();
        handToSave = SetHand(cardsSplited, handToSave);

        await _httpClient.PostAsJsonAsync("hand", handToSave);
    }
    public HandForCreationDto SetHand(string[] SplitedCard, HandForCreationDto hand)
    {
        hand.CardOne = SplitedCard[0];
        hand.CardTwo = SplitedCard[1];
        hand.CardThree = SplitedCard[2];
        hand.CardFour = SplitedCard[3];
        hand.CardFive = SplitedCard[4];
        return hand;
    }
}


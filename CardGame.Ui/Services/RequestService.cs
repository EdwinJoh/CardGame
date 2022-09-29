using Entities.Models;
using SharedHelpers.DataTransferObjects;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CardGame.Ui.Services;
/// <summary>
/// This class is responsible to call our API from our UI 
/// </summary>
public class RequestService : IRequestService
{

    private readonly HttpClient _httpClient;
    public RequestService(HttpClient httpClient) => _httpClient = httpClient;

    /// <summary>
    /// This method calls the API and gets all the cardhistory
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<CardHistoryDto>> GetAllCardHistoriesAsync()
    {
        var respons = await _httpClient.GetFromJsonAsync<IEnumerable<CardHistoryDto>>("card");
        return respons!;
    }

    /// <summary>
    /// This method calls the API and get an new card of deck to 
    /// </summary>
    /// <returns></returns>
    public async Task<List<CardDto>> GetNewDeck()
    {
        var respons = await _httpClient.GetFromJsonAsync<List<CardDto>>("card/deck");
        return respons!;
    }
    /// <summary>
    /// This method calls the api for saving the cards that the user have had in his "hand"
    /// </summary>
    /// <param name="hand"></param>
    /// <returns></returns>
    public async Task SaveHand(string hand)
    {
        HandForCreationDto handToSave = new HandForCreationDto();

        List<string> allCardsStored;
        allCardsStored = hand.Split(",").ToList();

        string[] cardsSplited = allCardsStored.ToArray();
        handToSave = SetHand(cardsSplited, handToSave);

        await _httpClient.PostAsJsonAsync("hand", handToSave);
    }

    /// <summary>
    /// This mehod saves the value to the hand for creation so we can save it to the database
    /// </summary>
    /// <param name="SplitedCard"></param>
    /// <param name="hand"></param>
    /// <returns></returns>
    public HandForCreationDto SetHand(string[] SplitedCard, HandForCreationDto hand)
    {
        hand.CardOne = SplitedCard[0];
        hand.CardTwo = SplitedCard[1];
        hand.CardThree = SplitedCard[2];
        hand.CardFour = SplitedCard[3];
        hand.CardFive = SplitedCard[4];
        return hand;
    }

    public async Task RemoveCard(int id)
    {
         await _httpClient.DeleteAsync($"card/delete/{id}");
    }
}


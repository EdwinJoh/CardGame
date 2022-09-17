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
    public async Task SaveHand(string hand) //Todo: create facotry for creation ?
    {
        HandForCreationDto createdHand = new HandForCreationDto();
        List<string> temp;
        temp = hand.Split(",").ToList();
        string[] test = temp.ToArray();
        createdHand = SetHand(test, createdHand);
        await _httpClient.PostAsJsonAsync("hand", createdHand);
    }
    public  HandForCreationDto SetHand(string[] temp,HandForCreationDto hand)
    {
        hand.CardOne = temp[0];
        hand.CardTwo = temp[1];
        hand.CardThree = temp[2];
        hand.CardFour = temp[3];
        hand.CardFive = temp[4];
        return hand;
    }

}

        //string one ="", two ="", three ="", four ="", five ="";
        //for (int i = 0; i < hand.Count; i++)
        //{
        //    if (i == 0)
        //        one = hand[i].NamedValue+" "+ hand[i].Suits;
        //    if (i == 1)
        //        two = hand[i].NamedValue + " " + hand[i].Suits; ; 
        //    if (i == 2)
        //        three = hand[i].NamedValue + " " + hand[i].Suits; ;
        //    if (i == 3)
        //        four = hand[i].NamedValue + " " + hand[i].Suits; ;
        //    if (i == 4)
        //        five = hand[i].NamedValue + " " + hand[i].Suits; ;
        //}
        //createdHand.CardOne = one;
        //createdHand.CardTwo = two;
        //createdHand.CardThree = three;
        //createdHand.CardFour = four;
        //createdHand.CardFive = five;
        //await _httpClient.PostAsJsonAsync("hand", createdHand);
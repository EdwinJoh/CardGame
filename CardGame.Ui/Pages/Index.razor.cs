using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace CardGame.Ui.Pages;

public partial class Index : ComponentBase
{
    private List<Card> CardDeck = new List<Card>();
    private List<Card> FiveCards = new List<Card>();
    private List<Card> RemovedCards = new();

    private bool GameStarted = false;

    protected override async Task OnInitializedAsync()
    {
        CardDeck = await _request.GetNewDeck();
    }
    private void StartGame()
    {
        FiveCards = CardDeck.Take(5).ToList();
        GameStarted = true;
    }

    private void OnClick()
    {
        SaveHand();
        CardDeck.RemoveAll(x => x.IsChecked == true);
        AddUsedCardToList(FiveCards);
        FiveCards.RemoveAll(x => x.IsChecked == true);
        CheckIfCardDeckNeedToBeFilled();
        AddNewCards();
    }


    private void AddNewCards()
    {
        foreach (var card in CardDeck)
            if (FiveCards.Count != 5 && !FiveCards.Contains(card))
                FiveCards.Add(card);
    }

    private void SaveHand()
    {
        string test = "";
        for (int i = 0; i < FiveCards.Count; i++)
            test += ($"{FiveCards[i].NamedValue} {FiveCards[i].Suits},");

        _request.SaveHand(test);
    }

    private void AddUsedCardToList(List<Card> fiveCards)
    {
        foreach (var card in fiveCards)
            if (card.IsChecked)
            {
                RemovedCards.Add(card);

            }
    }

    private void CheckIfCardDeckNeedToBeFilled()
    {
        if (CardDeck.Count <= 5)
            CardDeck.AddRange(RemovedCards);
    }
}

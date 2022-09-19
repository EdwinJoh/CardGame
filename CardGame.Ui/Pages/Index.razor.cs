using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace CardGame.Ui.Pages;

public partial class Index : ComponentBase
{
    private List<Card> CardDeck = new List<Card>();
    private List<Card> CardsInHand = new List<Card>();
    private List<Card> RemovedCards = new();
    private readonly int cardLeft = 1;

    private bool GameStarted = false;

    protected override async Task OnInitializedAsync()
    {
        CardDeck = await _request.GetNewDeck();
    }
    private void StartGame()
    {
        CardsInHand = CardDeck.Take(5).ToList();
        GameStarted = true;
    }

    private void OnClick()
    {
        SaveHand();
        CardDeck.RemoveAll(x => x.IsChecked == true);
        AddUsedCardToList(CardsInHand);
        CardsInHand.RemoveAll(x => x.IsChecked == true);
        CheckIfCardDeckNeedToBeFilled();
        AddNewCards();
    }


    private void AddNewCards()
    {
        foreach (var card in CardDeck)
            if (CardsInHand.Count != 5 && !CardsInHand.Contains(card))
                CardsInHand.Add(card);
    }

    private void SaveHand()
    {
        string test = "";
        for (int i = 0; i < CardsInHand.Count; i++)
            test += ($"{CardsInHand[i].NamedValue} {CardsInHand[i].Suits},");

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
        if (CardDeck.Count < cardLeft)
            CardDeck.AddRange(RemovedCards);
    }
}

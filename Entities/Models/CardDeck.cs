using Entities.Enums;
using System.Net.Http.Headers;

namespace Entities.Models;

public class CardDeck
{
    public int Id { get; set; }
    private const int NumberOfCards = 52;
    public List<Card> Cards = new();
    public Card CardPrototype = new();

    /// <summary>
    /// This method clones the card object insted of makeing an new instance of it when we create 
    /// an new deck.
    /// </summary>
    public List<Card> FillDeck()
    {
        for (int i = 0; i < NumberOfCards; i++)
        {
            CardSuit suite = (CardSuit)(Math.Floor((decimal)i / 13));
            int val = i % 13 + 2;
            Card cardCopy = (Card)CardPrototype.Clone();
            cardCopy.Rank = val;
            cardCopy.Suits = suite;
        }
        return Cards;
    }
}
//Todo:Flytta till service lagret ?

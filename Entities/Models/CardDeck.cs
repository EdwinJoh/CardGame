using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CardDeck
    {
        private const int NumberOfCards = 52;
        public List<Card> Cards = new();



        public void FillDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                CardSuit suite = (CardSuit)(Math.Floor((decimal)i / 13));
                
                int val = i % 13 + 2;
                Cards.Add(new Card(val, suite));
            }
        }
        public void PrintDeck()
        {
            foreach (var item in Cards)
                Console.WriteLine($"{item.NamedValue}, {item.Suits}");
        }
    }
}
        //Todo:Flytta till service lagret ?
        //Todo: Factory method för att skapa ett object som sparas till databasen inte kortleken?

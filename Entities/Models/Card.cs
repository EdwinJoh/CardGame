using Entities.Commons;
using Entities.Enums;

namespace Entities.Models;

public class Card : ICard
{
    public int Id { get; set; }
    public int Rank { get; set; }
    public CardSuit Suits { get; set; }
    public Card(int rank, CardSuit suits)
    {
        Rank = rank;
        Suits = suits;
    }
    public string NamedValue
    {
        get
        {
            string name = string.Empty;
            switch (Rank)
            {
                case (14):
                    name = "Ace";
                    break;
                case (13):
                    name = "King";
                    break;
                case (12):
                    name = "Queen";
                    break;
                case (11):
                    name = "Jack";
                    break;
                default:
                    name = Rank.ToString();
                    break;
            }
            return name;
        }
    }
}

using Entities.Commons;
using Entities.Enums;

namespace Entities.Models;

/// <summary>
/// ConcretePrototype class
/// </summary>
public class Card : ICard
{

    public int Rank { get; set; }
    public CardSuit Suits { get; set; }
    public bool IsChecked { get; set; }


    public ICard Clone()
    {
        return (ICard)MemberwiseClone();
    }

    public string NamedValue
    {
        get
        {
            string name = string.Empty;
            switch (Rank)
            {
                case (14):
                    name = $"Ace";
                    break;
                case (13):
                    name = $"King";
                    break;
                case (12):
                    name = $"Queen";
                    break;
                case (11):
                    name = $"Jack";
                    break;
                default:
                    name = $"{Rank.ToString()}";
                    break;
            }
            return name;
        }
    }

}

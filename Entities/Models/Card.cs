using Entities.Commons;
using Entities.Enums;

namespace Entities.Models;

public class Card : ICard
{
    
    public int Rank { get; set; }
    public CardSuit Suits { get; set; }
    

   public ICard Clone()
    {
        return (ICard)MemberwiseClone();
    }

    public void GetCard()
    {
        Console.WriteLine($"{Rank}, {Suits}");
    }
    public string NamedValue
    {
        get
        {
            string name = string.Empty;
            switch (Rank)
            {
                case (14):
                    name = $"Ace, {Suits}";
                    break;
                case (13):
                    name = $"King, {Suits}";
                    break;
                case (12):
                    name = $"Queen, { Suits}";
                    break;
                case (11):
                    name = $"Jack, {Suits}";
                    break;
                default:
                    name = $"{Rank.ToString()}, {Suits}";
                    break;
            }
            return name;
        }
    }
   
}

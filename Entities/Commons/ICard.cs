using Entities.Enums;

namespace Entities.Commons;

public interface ICard
{
    public int Rank { get; set; }
    public CardSuit Suits { get; set; }
    public CardColor Color { get; set; }
    
}

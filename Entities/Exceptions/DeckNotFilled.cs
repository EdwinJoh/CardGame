namespace Entities.Exceptions;

public class DeckNotFilled : NotFoundException
{
    public DeckNotFilled() : base("The Deck of cards is not filled with all the cards.")
    {
    }
}

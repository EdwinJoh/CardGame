namespace Entities.Exceptions;

public class CardNotFoundException : NotFoundException
{
    public CardNotFoundException(int id) : base($"Card with id {id} does not exsist in the database")
    {

    }
}

namespace Contacts.Interfaces;

public interface IRepositoryManager
{
    ICardRepository CardHistory { get; }
    void Save();
}

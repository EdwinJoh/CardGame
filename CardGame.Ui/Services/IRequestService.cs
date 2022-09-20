using Entities.Models;

namespace CardGame.Ui.Services;

public interface IRequestService
{
    Task<IEnumerable<CardHistory>> GetAllCardHistoriesAsync();
    Task<List<Card>> GetNewDeck();
    Task SaveHand(string Hand);
    Task RemoveCard(int id);
    
    
    
}

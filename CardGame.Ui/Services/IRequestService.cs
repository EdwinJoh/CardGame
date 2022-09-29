using Entities.Models;
using SharedHelpers.DataTransferObjects;

namespace CardGame.Ui.Services;

public interface IRequestService
{
    Task<IEnumerable<CardHistoryDto>> GetAllCardHistoriesAsync();
    Task<List<CardDto>> GetNewDeck();
    Task SaveHand(string Hand);
    Task RemoveCard(int id);
    
    
    
}

using Entities.Models;
using SharedHelpers.DataTransferObjects;

namespace Service.Contracts.Interfaces;

public interface ICardService
{
    Task<IEnumerable<CardHistoryDto>> GetAllCardHistoryAsync(bool trackChanges);
    Task<List<CardDto>> GetNewDeckAsync();
    List<Card> ShuffleDeckOfCards(List<Card> DeckOfCrads);
    void CheckIfDeckIsFilled(List<Card> cards);
    Task DeleteCardHistoryAsync(int id, bool trackChanges);
}

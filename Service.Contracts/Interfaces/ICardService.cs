using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts.Interfaces;

public interface ICardService
{
    Task<IEnumerable<CardHisotryDto>> GetAllCardHistoryAsync(bool trackChanges);
    Task<List<Card>> GetNewDeck();
    List<Card> ShuffleDeckOfCards(List<Card> DeckOfCrads);
}

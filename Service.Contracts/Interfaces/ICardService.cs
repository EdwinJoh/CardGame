using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts.Interfaces;

public interface ICardService
{
    Task<IEnumerable<CardHisotryDto>> GetAllCardHistoryAsync(bool trackChanges);
    Task<List<Card>> GetNewDeck();
}

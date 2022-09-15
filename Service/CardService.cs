using AutoMapper;
using Contacts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts.Interfaces;
using Shared.DataTransferObjects;

namespace Service;

public class CardService : ICardService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public CardService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CardHisotryDto>> GetAllCardHistoryAsync(bool trackChanges)
    {
        var cardHistory = await _repository.CardHistory.GetAllCardHistoryAsync(trackChanges);
        var cardHistoryDto = _mapper.Map<IEnumerable<CardHisotryDto>>(cardHistory);
        return cardHistoryDto;
    }

    public Task<List<Card>> GetNewDeck()
    {
        CardDeck newDeck = new();
        var deck = newDeck.FillDeck();

        CheckIfDeckIsFilled(deck);

        return Task.FromResult(deck.ToList());
    }

    public void CheckIfDeckIsFilled(List<Card> cards)
    {
        if (cards.Count < 52)
            throw new DeckNotFilled();
    }
}

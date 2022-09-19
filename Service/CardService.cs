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
    public CardDeck DeckCard { get; set; } = new CardDeck();
    public CardService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CardHistoryDto>> GetAllCardHistoryAsync(bool trackChanges)
    {
        var cardHistory = await _repository.CardHistory.GetAllCardHistoryAsync(trackChanges);
        var cardHistoryDto = _mapper.Map<IEnumerable<CardHistoryDto>>(cardHistory);
        return cardHistoryDto;
    }

    public Task<List<Card>> GetNewDeck()
    {

        var deck = DeckCard.FillDeck();
        deck = ShuffleDeckOfCards(deck);
        
        return Task.FromResult(deck.ToList());
    }

    public List<Card> ShuffleDeckOfCards(List<Card> DeckOfCards)
    {
        CheckIfDeckIsFilled(DeckOfCards);
        DeckOfCards = DeckCard.ShuffleCards(DeckOfCards);

        return DeckOfCards;
    }
    public void CheckIfDeckIsFilled(List<Card> cards)
    {
        if (cards.Count < 52)
            throw new DeckNotFilled();
    }
    
}

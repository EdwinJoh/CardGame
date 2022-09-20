using AutoMapper;
using Contacts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts.Interfaces;
using Shared.DataTransferObjects;

namespace Service;

/// <summary>
/// Service layer / business layer for the cards in the deck
/// </summary>
public class CardService : ICardService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly int deckSize = 52;
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

    public async Task<List<Card>> GetNewDeckAsync()
    {
        var newDeck = DeckCard.FillDeck();
        newDeck = ShuffleDeckOfCards(newDeck);

        return await Task.FromResult(newDeck.ToList());
    }

    public List<Card> ShuffleDeckOfCards(List<Card> DeckOfCards)
    {
        CheckIfDeckIsFilled(DeckOfCards);
        DeckOfCards = DeckCard.ShuffleCards(DeckOfCards);

        return DeckOfCards;
    }
    public void CheckIfDeckIsFilled(List<Card> cards)
    {
        if (cards.Count < deckSize)
        {
            _logger.LogError($"the deck is not filled " + new DeckNotFilled());
            throw new DeckNotFilled();

        }
    }
    public async Task DeleteCardHistoryAsync(int id, bool trackChanges)
    {
        await _repository.CardHistory.GetCardHistoryAsync(id, trackChanges);

        var cardHistory = await _repository.CardHistory.GetCardHistoryAsync(id, trackChanges);
        _repository.CardHistory.DeleteCardHistory(cardHistory);
        await _repository.SaveAsync();
    }


}

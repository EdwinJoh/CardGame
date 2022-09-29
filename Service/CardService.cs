using AutoMapper;
using Contacts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts.Interfaces;
using SharedHelpers.DataTransferObjects;

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
    /// <summary>
    /// This method Get all cardhistory from our Repository layer and map it to cardhistory Dto that retrun to the customer 
    /// </summary>
    /// <param name="trackChanges"></param>
    /// <returns></returns>
    public async Task<IEnumerable<CardHistoryDto>> GetAllCardHistoryAsync(bool trackChanges)
    {
        var cardHistory = await _repository.CardHistory.GetAllCardHistoryAsync(trackChanges);
        var cardHistoryDto = _mapper.Map<IEnumerable<CardHistoryDto>>(cardHistory);

        return cardHistoryDto;
    }

    /// <summary>
    /// This method create an new deck to the application and shuffle it so when
    ///  we return the list to the customer the list is shuffled
    /// </summary>
    /// <returns></returns>
    public async Task<List<CardDto>> GetNewDeckAsync()
    {
        var newDeck = DeckCard.FillDeck();
        newDeck = ShuffleDeckOfCards(newDeck);
        var newDeckDto = _mapper.Map<List<CardDto>>(newDeck);

        return await Task.FromResult(newDeckDto.ToList());
    }

    /// <summary>
    /// Take in one list of deck of cards and shuffle the card deck for the application
    /// </summary>
    /// <param name="DeckOfCards"></param>
    /// <returns></returns>
    public List<Card> ShuffleDeckOfCards(List<Card> DeckOfCards)
    {
        CheckIfDeckIsFilled(DeckOfCards);
        DeckOfCards = DeckCard.ShuffleCards(DeckOfCards);

        return DeckOfCards;
    }

    /// <summary>
    /// This method is responsible to check if the deck of cards is filled with the number of cards needed in a deck.
    /// </summary>
    /// <param name="cards">List of cards</param>
    /// <exception cref="DeckNotFilled"></exception>
    public void CheckIfDeckIsFilled(List<Card> cards)
    {
        if (cards.Count < deckSize)
        {
            _logger.LogError($"the deck is not filled " + new DeckNotFilled());
            throw new DeckNotFilled();

        }
    }

    /// <summary>
    /// This method calls the repository layer to delete an cardhistory from the database.
    /// </summary>
    /// <param name="id">Id of the cardhistory we want to remove.</param>
    /// <param name="trackChanges"></param>
    /// <returns></returns>
    public async Task DeleteCardHistoryAsync(int id, bool trackChanges)
    {
        await _repository.CardHistory.GetCardHistoryAsync(id, trackChanges);

        var cardHistory = await _repository.CardHistory.GetCardHistoryAsync(id, trackChanges);
        _repository.CardHistory.DeleteCardHistory(cardHistory);
        await _repository.SaveAsync();
    }


}

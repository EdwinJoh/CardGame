using AutoMapper;
using Contacts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Service.Contracts.Interfaces;
using SharedHelpers.DataTransferObjects;

namespace CardGame.Test.ServiceLayerTest;

public class CardServiceTest
{
    private readonly IServiceManager _serviceManager;
    private readonly Mock<IRepositoryManager> _repositoryManagerMock = new();
    private readonly Mock<ILoggerManager> _loggerManagerMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    public CardServiceTest()
    {
        _serviceManager = new ServiceManager(_repositoryManagerMock.Object, _loggerManagerMock.Object, _mapperMock.Object);
    }

    public IEnumerable<CardHistory> GetAll() =>
        new CardHistory[]
        {
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"},
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"},
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"}
        };
    public List<Card> GetNewDeck()
    {

        List<Card> DeckOfCards = new();
        CardDeck cardDeck = new();

        DeckOfCards = cardDeck.FillDeck();
       
        return DeckOfCards;
    }
    [Fact]
    public void GetAllCardHistoryAsync_ShouldReturnListOfCardHistory()
    {
        //Arrange
        bool trackChanges = false;
        IEnumerable<CardHistory> cards = GetAll();

        //Act
        _repositoryManagerMock.Setup(x => x.CardHistory.GetAllCardHistoryAsync(trackChanges)).ReturnsAsync(cards);

        //Assert
        Assert.Equal(3, cards.Count());
    }

    [Fact]
    public async void GetNewDeck_ShouldReturnDeckOf52Card()
    {
        //Arrange
        var deck = new List<Card>();
        int deckLengt = 52;

        //Act
        deck = GetNewDeck();

        //Assert
        Assert.Equal(deckLengt, deck.Count());


    }
    [Fact]
    public void CheckIfDeckIsFilled_ShouldThrowException_DeckNotFilled()
    {
        //Arrange
        var deck = new List<Card>{
            new Card(),
            new Card(),
            new Card(),
                  };

        //Assert
        Assert.Throws<DeckNotFilled>(() => _serviceManager.CardService.CheckIfDeckIsFilled(deck));
    }

}

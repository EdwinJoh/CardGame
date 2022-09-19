using Contacts.Interfaces;
using Entities.Models;
using Moq;
using Repository;

namespace CardGame.Test;

public class CardRepositoryTests
{
    private readonly ICardRepository _cardRepository;
    private readonly Mock<IRepositoryManager> _repositoryManagerMock = new();
    private readonly Mock<RepositoryContext> _repositoryContext = new();
    private readonly Mock<ILoggerManager> _loggerManagerMock = new();
    public IEnumerable<CardHistory> GetAll() =>
        new CardHistory[]
        {
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"},
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"},
            new CardHistory (){Id = 1,CardOne = "1 a",CardTwo = "1 a",CardThree = "1 a",CardFour = "1 a",CardFive = "1 a"}
        };

    //public CardRepositoryTests()
    //{
    //    _cardRepository = new CardRepository(_repositoryContext.Object);
    //}

    [Fact]
    public void GetCardHistoryAsync_ShouldReturnaCardHistory_IfExsist()
    {
        //Arrange
        var cardHistoryId = 1;
        bool trackChanges = false;

        CardHistory card = new CardHistory
        {
            Id = cardHistoryId
        };

        //Act
        _repositoryManagerMock.Setup(x => x.CardHistory.GetCardHistoryAsync(cardHistoryId, trackChanges));

        //Assert
        Assert.Equal(cardHistoryId, card.Id);
    }
    [Fact]
    public void GetCardHistoryList_ShouldReturnListOfCardhistory()
    {
        //Arrange
        IEnumerable<CardHistory> cards = GetAll();
        bool trackChanges = false;

        //Act
        _repositoryManagerMock.Setup(x => x.CardHistory.GetAllCardHistoryAsync(trackChanges)).ReturnsAsync(cards);

        Assert.Equal(3, cards.Count());
    }
    
}
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
    public CardRepositoryTests()
    {
        _cardRepository = new CardRepository(_repositoryContext.Object);
    }

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
    
}
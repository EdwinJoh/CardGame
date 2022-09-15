using AutoMapper;
using Contacts.Interfaces;
using Entities.Models;
using Microsoft.Identity.Client;
using Moq;
using Service;
using Service.Contracts.Interfaces;
using Shared.DataTransferObjects;
using System.Collections;

namespace CardGame.Test;

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

    [Fact]
    public async void GetAllCardHistoryAsync_ShouldReturnListOfCardHistory()
    {
        bool trackChanges = false;
        //Arrange
        IEnumerable<CardHistory> cards = GetAll();


        _repositoryManagerMock.Setup(x => x.CardHistory.GetAllCardHistoryAsync(trackChanges)).ReturnsAsync(cards);

        Assert.Equal(3, cards.Count());
    }
}

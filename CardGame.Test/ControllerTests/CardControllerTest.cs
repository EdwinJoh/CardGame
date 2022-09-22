﻿using CardGame.Presentation.Controllers;
using Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Contracts.Interfaces;
using Shared.DataTransferObjects;

namespace CardGame.Test.ControllerTests;

public class CardControllerTest
{
    private readonly IServiceManager serviceManager;
    private readonly bool trackChanges = false;

    [Theory]
    [InlineData(200)] // Ok
    [InlineData(204)] // noContent
    [InlineData(400)] // not found 
    public async Task Get_OnSuccsess_ReturnStatusCode200(int statusCode)
    {
        //Arrange
        var mockservice = new Mock<IServiceManager>();
        mockservice
            .Setup(x => x.CardService.GetAllCardHistoryAsync(trackChanges))
            .ReturnsAsync(new List<CardHistoryDto>());

        var sut = new CardController(mockservice.Object);

        //Act
        var result = (OkObjectResult)await sut.GetCardHistory();
        //Assert
        result.StatusCode.Should().Be(statusCode);
    }
    [Theory]
    [InlineData(200)] // Ok
    [InlineData(204)] // noContent
    [InlineData(400)] // not found 
    private async Task GetDeck_OnSuccsess_ReturnStatusCode200(int statusCode)
    {
        //Arrange
        var mockservice = new Mock<IServiceManager>();
        mockservice
            .Setup(x => x.CardService.GetNewDeckAsync())
            .ReturnsAsync(new List<Card>());
        var sut = new CardController(mockservice.Object);

        //Act
        var result = (OkObjectResult)await sut.GetNewDeck();

        //Assert
        result.StatusCode.Should().Be(statusCode);
    }
    [Theory]
    [InlineData(200)] // Ok
    [InlineData(204)] // noContent
    [InlineData(400)] // not found 
    public async Task DeleteCardHistory_ShoudReturnStatusCode204(int statusCode)
    {
        //Arrange
        var cardTemp = new CardHistory { Id =1};
        var mockservice = new Mock<IServiceManager>();
        mockservice
          .Setup(x => x.CardService.DeleteCardHistoryAsync(cardTemp.Id, trackChanges));
               

        var sut = new CardController(mockservice.Object);

        //Act
        var result = (NoContentResult)await sut.DeleteCardHistory(cardTemp.Id);
        //Assert
        result.StatusCode.Should().Be(statusCode);
    }
}

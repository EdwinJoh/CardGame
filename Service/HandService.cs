using AutoMapper;
using Contacts.Interfaces;
using Entities.Models;
using Service.Contracts.Interfaces;
using SharedHelpers.DataTransferObjects;

namespace Service;

/// <summary>
/// /// Service layer / business layer for the "hand" / cardhistory
/// </summary>
public class HandService :IHandService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public HandService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// This method calls the repository layer and save the cardhistory to the database
    /// </summary>
    /// <param name="hand">The cardhistory that we want to save to the database</param>
    /// <returns></returns>
    public async Task<CardHistoryDto> SaveHandAsync(HandForCreationDto hand)
    {
        var cardHistoryEntity = _mapper.Map<CardHistory>(hand);

        _repository.CardHistory.CreateCardHistory(cardHistoryEntity);
        await _repository.SaveAsync();

        var cardHistoryToReturn = _mapper.Map<CardHistoryDto>(cardHistoryEntity);
        return cardHistoryToReturn;
    }
   


}

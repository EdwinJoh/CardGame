using AutoMapper;
using Contacts.Interfaces;
using Entities.Models;
using Service.Contracts.Interfaces;
using Shared.DataTransferObjects;

namespace Service;

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
    public async Task<CardHistoryDto> SaveHandAsync(HandForCreationDto hand)
    {
        var cardHistoryEntity = _mapper.Map<CardHistory>(hand);

        _repository.CardHistory.CreateCardHistory(cardHistoryEntity);
        await _repository.SaveAsync();

        var cardHistoryToReturn = _mapper.Map<CardHistoryDto>(cardHistoryEntity);
        return cardHistoryToReturn;
    }
   


}

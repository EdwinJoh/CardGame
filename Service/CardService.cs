using AutoMapper;
using Contacts.Interfaces;
using Service.Contracts.Interfaces;

namespace Service;

public class CardService : ICardService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public CardService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
}

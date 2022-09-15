using AutoMapper;
using Contacts.Interfaces;
using Service.Contracts.Interfaces;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<CardService> _cardHistoryService;
    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
    logger, IMapper mapper)
    {
        _cardHistoryService = new Lazy<CardService>(() => new
        CardService(repositoryManager, logger, mapper));

    }
    public ICardService CardService => _cardHistoryService.Value;


}

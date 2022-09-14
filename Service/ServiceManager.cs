using AutoMapper;
using Contacts.Interfaces;
using Service.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<CardHistoryService> _cardHistoryService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper)
        {
            _cardHistoryService = new Lazy<CardHistoryService>(() => new
            CardHistoryService(repositoryManager, logger, mapper));

        }
        public CardHistoryService TestModelService => _cardHistoryService.Value;


    }
}

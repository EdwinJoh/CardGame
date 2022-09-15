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
        private readonly Lazy<CardService> _cardHistoryService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper)
        {
            _cardHistoryService = new Lazy<CardService>(() => new
            CardService(repositoryManager, logger, mapper));

        }
        public CardService TestModelService => _cardHistoryService.Value;


    }
}

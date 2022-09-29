using Entities.Models;
using SharedHelpers.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Interfaces
{
    public interface IHandService
    {
        Task<CardHistoryDto> SaveHandAsync(HandForCreationDto hand);
      
    }
}

using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CardRepository : RepositoryBase<CardHistory>, ICardRepository
    {
        public CardRepository(RepositoryContext repository) : base(repository)
        {
        }
        public async Task<IEnumerable<CardHistory>> GetAllCardHistoryAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(x => x.Id).ToListAsync();

        public async Task<CardHistory> GetCardHistoryAsync(int id, bool trackChangs) =>
            await FindByCondition(x => x.Id.Equals(id), trackChangs).SingleOrDefaultAsync();
    }
}

using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class CardRepository : RepositoryBase<CardHistory>, ICardRepository
{
    public CardRepository(RepositoryContext repository) : base(repository)
    {
    }

    /// <summary>
    /// This method calls the database and gets all the cardhistory to the application.
    /// </summary>
    /// <param name="trackChanges"></param>
    /// <returns></returns>
    public async Task<IEnumerable<CardHistory>> GetAllCardHistoryAsync(bool trackChanges) =>
        await FindAll(trackChanges).OrderBy(x => x.Id).ToListAsync();

    /// <summary>
    /// This method get one specific cardhistory from the database to the application
    /// </summary>
    /// <param name="id"></param>
    /// <param name="trackChangs"></param>
    /// <returns></returns>
    public async Task<CardHistory> GetCardHistoryAsync(int id, bool trackChangs) =>
        await FindByCondition(x => x.Id.Equals(id), trackChangs).SingleOrDefaultAsync();


    /// <summary>
    /// Create and object to the database
    /// </summary>
    /// <param name="card"></param>
    public void CreateCardHistory(CardHistory card) => Create(card);

    /// <summary>
    /// Delete one object from the database 
    /// </summary>
    /// <param name="card"></param>
    public void  DeleteCardHistory(CardHistory card) => Delete(card);
}

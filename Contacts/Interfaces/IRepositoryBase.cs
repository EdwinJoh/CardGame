using System.Linq.Expressions;

namespace Contacts.Interfaces;

/// <summary>
/// Generic Interface for the repository
/// </summary>
/// <typeparam name="T"></typeparam>
/// 
public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
    bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}

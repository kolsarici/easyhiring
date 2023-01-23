using System.Linq.Expressions;
using EasyHiring.Domain.Entities;

namespace EasyHiring.Repository.Abstract;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(Guid id, bool isActive = true);
    Task<List<TEntity>> AllAsync(bool isActive = true);
    Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true);
    Task<IList<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true);
    Task SaveAsync(TEntity entity);
    //to do update has to be async
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true);
    /*Task<PagedList<TEntity>> FilterByPagingAsync(Expression<Func<TEntity, bool>> predicate,
        PagerInput pagerInput);*/
    Task Delete(TEntity entity);
}
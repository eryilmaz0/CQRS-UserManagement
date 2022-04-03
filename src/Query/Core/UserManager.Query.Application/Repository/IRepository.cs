using System.Linq.Expressions;
using UserManagement.Query.Domain.Entity;

namespace UserManager.Query.Application.Repository;

public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
{
    public Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
    public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);
    public Task Insert(TEntity entity);
    public Task Delete(TEntity entity);
    public Task Update(TEntity entity);
}
using System.Linq.Expressions;
using UserManagement.Command.Domain.Entity.Abstract;

namespace UserManagement.Command.Application.Repository;

public interface IRepository<TEntity> where TEntity: IEntity
{
    public Task<ICollection<TEntity>> GetAllAsync();
    public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);
    public Task<bool> InsertAsync(TEntity entity);
    public Task<bool> UpdateAsync(TEntity entity);
    public Task<bool> DeleteAsync(TEntity entity);
}
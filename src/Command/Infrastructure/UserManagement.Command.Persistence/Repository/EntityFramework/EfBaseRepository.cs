using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UserManagement.Command.Application.Repository;
using UserManagement.Command.Domain.Entity.Abstract;
using UserManagement.Command.Persistence.Context;

namespace UserManagement.Command.Persistence.Repository.EntityFramework;

public class EfBaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private CommandAppContext _context;

    public EfBaseRepository(CommandAppContext context)
    {
        _context = context;
    }

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
    }
    

    public async Task<bool> InsertAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return true;
    }
    

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }
    

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
    
}
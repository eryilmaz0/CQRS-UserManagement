using System.Linq.Expressions;
using MongoDB.Driver;
using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.Repository;

namespace UserManager.Query.Persistence.Mongo;

public class MongoGenericRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
{
    private readonly IMongoContext _context;
    private readonly IMongoCollection<TEntity> _collection;


    public MongoGenericRepository(IMongoContext context)
    {
        _context = context;
        _collection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
    }
    

    public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        if (filter is null)
            return await this._collection.Find(x => true).ToListAsync();

        return await this._collection.Find(filter).ToListAsync();
    }
    

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await this._collection.Find(filter).FirstOrDefaultAsync();
    }
    
    
    public async Task Insert(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
    }


    public async Task Delete(TEntity entity)
    {
        await _collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
    }


    public async Task Update(TEntity entity)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id.Equals(entity.Id), entity);
    }
}
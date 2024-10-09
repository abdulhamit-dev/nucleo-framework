using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Nucleo.Data.MongoDB
{
    public class BaseRepository<T, TKey> : IRepository<T, TKey> where T : class, IEntityBase<TKey>, new()
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public virtual async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var filter = Builders<T>.Filter.Where(predicate);
            return await _collection.Find(filter).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(e => !e.IsDeleted).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(TKey id)
        {
            var filter = Builders<T>.Filter.Eq(e => e.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public virtual async Task RemoveAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq(e => e.Id, entity.Id);
            await _collection.DeleteOneAsync(filter);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            var ids = entities.Select(e => e.Id);
            var filter = Builders<T>.Filter.In(e => e.Id, ids);
            await _collection.DeleteManyAsync(filter);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq(e => e.Id, entity.Id);
            await _collection.ReplaceOneAsync(filter, entity);
        }
    }
}

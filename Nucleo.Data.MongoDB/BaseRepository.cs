using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Nucleo.Data.MongoDB
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public async Task AddAsync(T entity)
        {
          await _collection.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
           await _collection.InsertManyAsync(entities);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var filter = Builders<T>.Filter.Where(predicate);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(T entity)
        {
           await _collection.DeleteOneAsync(e => e.Id == entity.Id);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
           await _collection.DeleteManyAsync(e => entities.Select(x => x.Id).Contains(e.Id));
        }

        public async Task UpdateAsync(T entity)
        {
           await _collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
        }
    }
}

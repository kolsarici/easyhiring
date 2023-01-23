using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using EasyHiring.Domain.Entities;
using EasyHiring.Repository.Abstract;
using Microsoft.Extensions.Options;

namespace EasyHiring.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly IMongoCollection<T> _collection;

        protected GenericRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.Database);
            _collection = db.GetCollection<T>(typeof(T).Name);
        }

        public Task<T> GetByIdAsync(Guid id, bool isActive = true)
        {
            return _collection.Find(x => x.Id == id && x.IsActive == isActive).FirstOrDefaultAsync();
        }

        public Task<List<T>> AllAsync(bool isActive = true)
        {
            return _collection.Find(c => c.IsActive == isActive).ToListAsync();
        }

        public Task<T> FindByAsync(Expression<Func<T, bool>> predicate, bool isActive = true)
        {
            return _collection.AsQueryable().Where(predicate).Where(x => x.IsActive == isActive).FirstOrDefaultAsync();
        }

        public async Task<IList<T>> FilterByAsync(Expression<Func<T, bool>> predicate, bool isActive = true)
        {
            return await _collection.AsQueryable().Where(predicate).Where(c => c.IsActive == isActive).ToListAsync();
        }

        public async Task SaveAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await _collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> predicate, bool isActive = true)
        {
            return _collection.AsQueryable().Where(predicate).Where(s => s.IsActive == isActive).CountAsync();
        }

        public async Task Delete(T entity)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }
    }
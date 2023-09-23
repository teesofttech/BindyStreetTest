using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Common;
using BindyStreet.Persistence.Extensions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BindyStreet.Persistence.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly IMongoBookDBContext _mongoContext;
        protected IMongoCollection<T> _dbCollection;

        protected MongoRepository(IMongoBookDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<T>(typeof(T).Name);
        }

        private int GetNextId()
        {
            var latestDocument = _dbCollection.Find(_ => true)
                .SortByDescending(document => document.Id)
                .Limit(1)
                .FirstOrDefault();

            // Increment the id and return the next value
            int nextId = (latestDocument == null) ? 1 : latestDocument.Id + 1;
            return nextId;
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(typeof(T).Name + " object is null");
            }
            entity.Id = GetNextId();
            await _dbCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            var objectId = new BsonInt32(entity.Id);
            await _dbCollection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var all = await _dbCollection.FindAsync(Builders<T>.Filter.Empty);
            return await all.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var objectId = new BsonInt32(id);

            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", objectId);

            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public Task<T> GetEntityWithSpec(ISpecifications<T> specification)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> specification)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(T entity)
        {
            var id = GetId(entity);
            await _dbCollection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);
            return entity;
        }

        private int GetId(T entity)
        {
            if (entity is T entityWithObjectId)
            {
                return entityWithObjectId.Id;
            }

            throw new InvalidOperationException("Entity does not have an ObjectId property.");
        }
    }
}

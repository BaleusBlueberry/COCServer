using System.Linq.Expressions;
using DLA.Interface;
using DLA.Models;
using DLA.Services;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DLA.Repository
{
    public class MongoRepository<T>(IMongoService mongo, string collectionName) : IRepository<T> where T : IEntity
    {
        protected readonly IMongoCollection<T> _collection = mongo.GetCollection<T>(collectionName);

        public virtual async Task Add(T item)
        {
            await _collection.InsertOneAsync(item);
        }

        public virtual async Task<T>? GetById(string id)
        {
            if (!IsValidObjectId.IsValidId(id)) return default(T);
            else return await _collection.Find(i => i.Id == id).FirstOrDefaultAsync();
            
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var items = await _collection.FindAsync(i => true);
            return await items.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            var items = await _collection.FindAsync(predicate);
            return await items.ToListAsync();
        }

        public virtual async Task<T>? FindOne(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task Update(T entity)
        {
            await _collection.ReplaceOneAsync(i => i.Id == entity.Id, entity);
        }

        public virtual async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(i => i.Id == id);
        }


        public virtual async Task Delete(T entity)
        {
            await _collection.DeleteOneAsync(i => i.Id == entity.Id);
        }

        public virtual async Task Delete(Expression<Func<T, bool>> predicate)
        {
            await _collection.DeleteManyAsync(predicate);
        }

        public virtual async Task DropCollectionAsync()
        {
            var database = _collection.Database;
            await database.DropCollectionAsync(_collection.CollectionNamespace.CollectionName);
        }
    }
}

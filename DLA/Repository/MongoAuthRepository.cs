using Humanizer;
using MongoDB.Driver;
using System.Linq.Expressions;
using DLA.Interface;

namespace DLA.Repository
{
    public class MongoAuthRepository<T>(IMongoService mongo)
    {
        protected readonly IMongoCollection<T> _collection = mongo.GetCollection<T>(typeof(T).Name.Pluralize());

        public virtual async Task Add(T item)
        {
            await _collection.InsertOneAsync(item);
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

        public virtual async Task Delete(Expression<Func<T, bool>> predicate)
        {
            await _collection.DeleteManyAsync(predicate);
        }


    }
}

using DLA.Models;
using MongoDB.Driver;

namespace DLA.Interface
{
    public interface IMongoService
    {
        public IMongoCollection<T> GetCollection<T>(string name);
    }
}

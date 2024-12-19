using DLA.Models;
using System.Linq.Expressions;

namespace DLA.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        Task Add(T entity);

        Task<T>? GetById(string id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate);

        Task<T>? FindOne(Expression<Func<T, bool>> predicate);

        Task Update(T entity);

        Task Delete(string id);

        Task Delete(T entity);

        Task Delete(Expression<Func<T, bool>> predicate);
    }
}

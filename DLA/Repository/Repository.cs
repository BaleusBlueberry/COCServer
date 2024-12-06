using DLA.Data;
using DLA.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLA.Repository;

    public abstract class Repository<T>(ContextDLA context) : IRepository<T> where T : class, IEntity
    {
        readonly DbSet<T> _dbSet = context.Set<T>();
        public virtual async Task Add(T entity)
        {
            //context.Products.add
            await _dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

    public virtual async Task<T>? GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T>? FindOne(Expression<Func<T, bool>> predicate)
        {
        return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public virtual async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            var item = await GetById(id)! ?? throw new ArgumentException("Item Not Found");
            await Delete(item);
        }

        public virtual async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(Expression<Func<T, bool>> predicate)
        {
            _dbSet.RemoveRange(await FindAll(predicate));
            await context.SaveChangesAsync();
        }
    }

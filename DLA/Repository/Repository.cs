using DLA.Data;
using DLA.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLA.Repository;

    public abstract class Repository<T>(ContextDLA context) : IRepository<T> where T : class, IEntity
    {
        readonly DbSet<T> DbSet = context.Set<T>();
        public virtual async Task Add(T entity)
        {
            //context.Products.add
            await DbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<T>? GetById(int id)
        {

            return await DbSet.FindAsync(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T>? FindOne(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.SingleOrDefaultAsync(predicate);
        }

        public virtual async Task Update(T entity)
        {
            DbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            var item = await GetById(id) ?? throw new ArgumentException("Item Not Found");
            Delete(item);
        }

        public virtual async Task Delete(T entity)
        {
            DbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(Expression<Func<T, bool>> predicate)
        {
            DbSet.RemoveRange(await FindAll(predicate));
            await context.SaveChangesAsync();
        }
    }

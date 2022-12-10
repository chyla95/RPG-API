using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;

        public Repository(DataContext dataContext)
        {
            _dbSet = dataContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetMany(string? propertiesToInclude = null, bool isTrackingEnabled = true)
        {
            IQueryable<T> query = _dbSet.Select(e => e);
            if(!isTrackingEnabled) query.AsNoTracking();

            if (!propertiesToInclude.IsNullOrEmpty())
            {
                IEnumerable<string> propertyNames = propertiesToInclude!.Split(new char[] { ',' }, StringSplitOptions.TrimEntries);
                foreach (string propertyName in propertyNames)
                {
                    query = query.Include(propertyName);
                }
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> predicate, string? propertiesToInclude = null, bool isTrackingEnabled = true)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            if (!isTrackingEnabled) query.AsNoTracking();

            if (!propertiesToInclude.IsNullOrEmpty())
            {
                IEnumerable<string> propertyNames = propertiesToInclude!.Split(new char[] { ',' }, StringSplitOptions.TrimEntries);
                foreach (string propertyName in propertyNames)
                {
                    query = query.Include(propertyName);
                }
            }

            return await query.ToListAsync();
        }
        public async Task<T?> GetOne(Expression<Func<T, bool>> predicate, string? propertiesToInclude = null, bool isTrackingEnabled = true)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            if (!isTrackingEnabled) query.AsNoTracking();

            if (!propertiesToInclude.IsNullOrEmpty())
            {
                IEnumerable<string> propertyNames = propertiesToInclude!.Split(new char[] { ',' }, StringSplitOptions.TrimEntries);
                foreach (string propertyName in propertyNames)
                {
                    query = query.Include(propertyName);
                }
            }

            T? entity = await query.SingleOrDefaultAsync();
            return entity;
        }
        public void AddOne(T entity)
        {
            _dbSet.Add(entity);
        }
        public virtual void UpdateOne(T entity)
        {
            _dbSet.Update(entity);
        }
        public void RemoveOne(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}

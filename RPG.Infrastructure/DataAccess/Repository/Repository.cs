using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;


        public Repository(DataContext dataContext)
        {
            _dbSet = dataContext.Set<T>();
        }


        public async Task AddEntity(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task<IEnumerable<T>> GetEntities(string? propertiesToInclude = null)
        {
            IQueryable<T> query = _dbSet.Select(e => e);

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
        public async Task<IEnumerable<T>> GetEntities(Expression<Func<T, bool>> predicate, string? propertiesToInclude = null)
        {
            IQueryable<T> query = _dbSet.Where(predicate);

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
        public async Task<T> GetEntity(Expression<Func<T, bool>> predicate, string? propertiesToInclude = null)
        {
            IQueryable<T> query = _dbSet.Where(predicate);

            if (!propertiesToInclude.IsNullOrEmpty())
            {
                IEnumerable<string> propertyNames = propertiesToInclude!.Split(new char[] { ',' }, StringSplitOptions.TrimEntries);
                foreach (string propertyName in propertyNames)
                {
                    query = query.Include(propertyName);
                }
            }

            return await query.SingleAsync();
        }
        public void RemoveEntity(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void UpdateEntity(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}

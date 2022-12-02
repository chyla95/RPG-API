using System.Linq.Expressions;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetEntities(Expression<Func<T, bool>> predicate, string? propertiesToInclude = null);
        Task<IEnumerable<T>> GetEntities(string? propertiesToInclude = null);
        Task<T> GetEntity(Expression<Func<T, bool>> predicate, string? propertiesToInclude = null);
        Task AddEntity(T entity);
        void RemoveEntity(T entity);
        void UpdateEntity(T entity);
    }
}

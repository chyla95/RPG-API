using System.Linq.Expressions;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> predicate, string? propertiesToInclude = null, bool isTrackingEnabled = true);
        Task<IEnumerable<T>> GetMany(string? propertiesToInclude = null, bool isTrackingEnabled = true);
        Task<T?> GetOne(Expression<Func<T, bool>> predicate, string? propertiesToInclude = null, bool isTrackingEnabled = true);
        void AddOne(T entity);
        void UpdateOne(T entity);
        void RemoveOne(T entity);
    }
}

using RPG.Domain.Model.General;

namespace RPG.Application.Services
{
    public interface IService<T> where T : Entity
    {
        Task<IEnumerable<T>> GetMany();
        Task<T?> GetOne(int id);
        Task AddOne(T role);
        Task UpdateOne(T role);
        Task RemoveOne(T role);
    }
}

using RPG.Domain.Model.General;

namespace RPG.Application.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetMany();
        Task<Role?> GetOne(int id);
        Task<Role?> GetOne(string name);
        Task AddOne(Role role);
        Task UpdateOne(Role role);
        Task RemoveOne(Role role);
    }
}

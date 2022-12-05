using RPG.Domain.Model.General;

namespace RPG.Application.Services
{
    public interface IRoleService : IService<Role>
    {
        Task<Role?> GetOne(string name);
    }
}

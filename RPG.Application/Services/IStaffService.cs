using RPG.Domain.Model.General;

namespace RPG.Application.Services
{
    public interface IStaffService : IService<Staff>
    {
        Task<Staff?> GetOne(string email);
    }
}

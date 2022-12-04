using RPG.Domain.Model.General;

namespace RPG.Application.Services
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetMany();
        Task<Staff?> GetOne(int id);
        Task<Staff?> GetOne(string email);
        Task AddOne(Staff user);
        Task UpdateOne(Staff user);
        Task RemoveOne(Staff user);
    }
}

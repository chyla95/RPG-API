using RPG.Domain.Model.General;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.Application.Repository
{
    public interface IStaffRepository : IRepository<Staff>
    {
        void AddRole(Staff entity, Role role);
        void RemoveRole(Staff entity, Role role);
    }
}

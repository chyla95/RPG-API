using RPG.Application.Repository;
using RPG.Domain.Model.General;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(DataContext dataContext) : base(dataContext) { }

        public void AddRole(Staff staff, Role role)
        {
            _ = staff.Roles.Append(role);
        }

        public void RemoveRole(Staff staff, Role role)
        {
            staff.Roles = staff.Roles.Where(r => r != role);
        }
    }
}

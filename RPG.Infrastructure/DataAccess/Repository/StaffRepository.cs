using RPG.Application.Repository;
using RPG.Domain.Model.General;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(DataContext dataContext) : base(dataContext) { }
    }
}

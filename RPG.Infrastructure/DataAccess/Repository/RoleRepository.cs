using RPG.Application.Repository;
using RPG.Domain.Model.General;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext dataContext) : base(dataContext) { }
        // ...
    }
}

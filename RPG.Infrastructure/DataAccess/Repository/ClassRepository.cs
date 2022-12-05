using RPG.Application.Repository;
using RPG.Domain.Model.Game;
using RPG.Infrastructure.DataAccess;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(DataContext dataContext) : base(dataContext) { }
    }
}

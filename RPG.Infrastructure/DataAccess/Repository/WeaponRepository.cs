using RPG.Application.Repository;
using RPG.Domain.Model.Game;
using RPG.Infrastructure.DataAccess;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public class WeaponRepository : Repository<Weapon>, IWeaponRepository
    {
        public WeaponRepository(DataContext dataContext) : base(dataContext) { }
    }
}

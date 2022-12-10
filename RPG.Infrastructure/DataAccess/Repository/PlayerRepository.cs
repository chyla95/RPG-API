using RPG.Application.Repository;
using RPG.Domain.Model.Game;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(DataContext dataContext) : base(dataContext)
        {
            //
        }
    }
}

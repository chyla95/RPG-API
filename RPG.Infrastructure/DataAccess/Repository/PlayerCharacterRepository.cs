using RPG.Application.Repository;
using RPG.Domain.Model.Game;

namespace RPG.Infrastructure.DataAccess.Repository
{
    internal class PlayerCharacterRepository : Repository<PlayerCharacter>, IPlayerCharacterRepository
    {
        public PlayerCharacterRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}

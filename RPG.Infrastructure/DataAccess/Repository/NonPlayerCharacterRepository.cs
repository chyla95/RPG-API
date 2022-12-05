using RPG.Application.Repository;
using RPG.Domain.Model.Game;

namespace RPG.Infrastructure.DataAccess.Repository
{
    public class NonPlayerCharacterRepository : Repository<NonPlayerCharacter>, INonPlayerCharacterRepository
    {
        public NonPlayerCharacterRepository(DataContext dataContext) : base(dataContext) { }
        // ...
    }
}

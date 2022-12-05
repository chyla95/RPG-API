using RPG.Domain.Model.Game;
using RPG.Infrastructure.DataAccess.Repository;

namespace RPG.Application.Repository
{
    public interface INonPlayerCharacterRepository : IRepository<NonPlayerCharacter>
    {
        // ...
    }
}

using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;

namespace RPG.API.Public.Utilities
{
    public interface ICurrentUser
    {
        Player GetCurrentUser();
    }
}

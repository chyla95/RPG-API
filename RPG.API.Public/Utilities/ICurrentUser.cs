using RPG.Domain.Model.General;

namespace RPG.API.Public.Utilities
{
    public interface ICurrentUser
    {
        Staff GetCurrentUser();
    }
}

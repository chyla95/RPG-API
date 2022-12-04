using RPG.Domain.Model.General;

namespace RPG.API.Management.Utilities
{
    public interface ICurrentUser
    {
        Staff GetCurrentUser();
    }
}

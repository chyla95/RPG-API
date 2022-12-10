using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;

namespace RPG.Application.Services
{
    public interface IPlayerService : IService<Player>
    {
        Task<Player?> GetOne(string email);
        Task<bool> IsEmailTaken(string email, int? entityId = null);
    }
}

using RPG.Domain.Model.Game;

namespace RPG.Application.Services
{
    public interface IPlayerCharacterService : IService<PlayerCharacter>
    {
        Task<PlayerCharacter?> GetOne(string name);
        Task<bool> IsNameTaken(string name, int? entityId = null);
    }
}

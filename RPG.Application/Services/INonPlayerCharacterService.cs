using RPG.Domain.Model.Game;

namespace RPG.Application.Services
{
    public interface INonPlayerCharacterService : IService<NonPlayerCharacter>
    {
        Task<NonPlayerCharacter?> GetOne(string name);
    }
}

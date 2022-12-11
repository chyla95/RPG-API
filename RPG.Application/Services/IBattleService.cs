using RPG.Domain.Model.Game;

namespace RPG.Application.Services
{
    public interface IBattleService
    {
        Task<Battle> Start1vs1BattleAsync(PlayerCharacter attacker, PlayerCharacter defender);
        Task<IEnumerable<PlayerCharacter>> GetRankingAsync();
    }
}

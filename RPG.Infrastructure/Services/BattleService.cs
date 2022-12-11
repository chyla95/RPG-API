using Microsoft.EntityFrameworkCore;
using RPG.Application.Services;
using RPG.Domain.Model.Game;
using RPG.Infrastructure.DataAccess;

namespace RPG.Infrastructure.Services
{
    internal class BattleService : IBattleService
    {
        private readonly DataContext _dataContext;

        public BattleService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Battle> Start1vs1BattleAsync(PlayerCharacter attacker, PlayerCharacter defender)
        {
            Battle pvpBattle = new(attacker, defender);
            ((PlayerCharacter)pvpBattle.Attacker).PvpFightCount++;
            ((PlayerCharacter)pvpBattle.Defender).PvpFightCount++;
            if (!pvpBattle.IsTie)
            {
                if (pvpBattle.Winner == null || pvpBattle.Loser == null) throw new Exception("Something went wrong...");
                ((PlayerCharacter)pvpBattle.Winner).PvpWinCount++;
                ((PlayerCharacter)pvpBattle.Loser).PvpLoseCount++;
            }
            await _dataContext.SaveChangesAsync();

            return pvpBattle;
        }

        public async Task<IEnumerable<PlayerCharacter>> GetRankingAsync()
        {
            IEnumerable<PlayerCharacter> characters = await _dataContext.PlayerCharacters
                .Where(c => c.PvpFightCount > 0)
                .Include(c => c.Weapon)
                 .Include(c => c.Class)
                .OrderByDescending(c => c.PvpWinCount)
                .ThenBy(c => c.PvpFightCount)
                .ToListAsync();

            return characters;
        }
    }
}



using RPG.Domain.Dtos.PlayerCharacter;

namespace RPG.Domain.Dtos.Battle
{
#pragma warning disable CS8618
    public class BattleResponseDto
    {
        public PlayerCharacterResponseDto Attacker { get; private set; }
        public PlayerCharacterResponseDto Defender { get; private set; }
        public PlayerCharacterResponseDto? Winner { get; private set; }
        public PlayerCharacterResponseDto? Loser { get; private set; }
        public bool IsTie { get; private set; } = false;
        public List<BattleTurnResponseDto> BattleTurns { get; private set; } = new();
    }
#pragma warning restore CS8618
}

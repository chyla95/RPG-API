using RPG.Domain.Dtos.PlayerCharacter;

namespace RPG.Domain.Dtos.Battle
{
#pragma warning disable CS8618
    public class BattleTurnResponseDto
    {
            private PlayerCharacterResponseDto Attacker { get; set; }
            private PlayerCharacterResponseDto Defender { get; set; }
            public int AttackerDamage { get; private set; }
            public int DefenderDamage { get; private set; }
    }
#pragma warning restore CS8618
}

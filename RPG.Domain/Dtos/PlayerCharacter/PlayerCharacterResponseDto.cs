using RPG.Domain.Dtos.Class;
using RPG.Domain.Dtos.Weapon;

namespace RPG.Domain.Dtos.PlayerCharacter
{
#pragma warning disable CS8618
    public class PlayerCharacterResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int CriticalHitChancePercentage { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Stamina { get; set; }
        public int Luck { get; set; }

        public int UnassignedStatisticPointsCount { get; set; }

        public int PvpFightCount { get; set; }
        public int PvpWinCount { get; set; }
        public int PvpLoseCount { get; set; }

        public ClassResponseDto Class { get; set; }
        public WeaponResponseDto Weapon { get; set; }
    }
#pragma warning restore CS8618
}

using RPG.Domain.Dtos.Weapon;

namespace RPG.Domain.Dtos.NonPlayerCharacter
{
#pragma warning disable CS8618
    public class NonPlayerCharacterResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int CriticalHitChancePercentage { get; set; }

        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }
        public virtual int Stamina { get; set; }
        public virtual int Luck { get; set; }

        public bool CanBeScaled { get; set; }

        public WeaponResponseDto? Weapon { get; set; }
    }
#pragma warning restore CS8618
}

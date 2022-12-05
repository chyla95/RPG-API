using RPG.Domain.Dtos.Class;

namespace RPG.Domain.Dtos.Weapon
{
#pragma warning disable CS8618
    public class WeaponResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }

        public ClassResponseDto Class { get; set; }
    }
#pragma warning restore CS8618
}

namespace RPG.Domain.Dtos.Weapon
{
#pragma warning disable CS8618
    public class WeaponResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
    }
#pragma warning restore CS8618
}

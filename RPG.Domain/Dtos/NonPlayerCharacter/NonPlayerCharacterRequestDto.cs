namespace RPG.Domain.Dtos.NonPlayerCharacter
{
#pragma warning disable CS8618
    public class NonPlayerCharacterRequestDto
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }
        public virtual int Stamina { get; set; }
        public virtual int Luck { get; set; }

        public bool CanBeScaled { get; set; }

        public int? WeaponId { get; set; }
    }
#pragma warning restore CS8618
}

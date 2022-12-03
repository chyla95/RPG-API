namespace RPG.Domain.Dtos.Class
{
#pragma warning disable CS8618
    public class ClassRequestDto
    {
        public string Name { get; set; }

        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseStamina { get; set; }
        public int BaseLuck { get; set; }

        public int AttackLevelMultiplier { get; set; }
        public int DefenseLevelMultiplier { get; set; }
        public int StaminaLevelMultiplier { get; set; }
        public int LuckLevelMultiplier { get; set; }
    }
#pragma warning restore CS8618
}

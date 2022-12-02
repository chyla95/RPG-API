using System.ComponentModel.DataAnnotations;
using RPG.Domain.Model.General;

namespace RPG.Domain.Model.Game
{
#pragma warning disable CS8618
    public class Class : Entity
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int BaseAttack { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int BaseDefense { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int BaseStamina { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int BaseLuck { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int AttackLevelMultiplier { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int DefenseLevelMultiplier { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int StaminaLevelMultiplier { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int LuckLevelMultiplier { get; set; }
    }
#pragma warning restore CS8618
}

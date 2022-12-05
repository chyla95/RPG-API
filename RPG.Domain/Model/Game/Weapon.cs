using System.ComponentModel.DataAnnotations;
using RPG.Domain.Model.General;

namespace RPG.Domain.Model.Game
{
#pragma warning disable CS8618
    public class Weapon : Entity
    {
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Damage { get; set; }

        [Required]
        public Class Class { get; set; }
    }
#pragma warning restore CS8618
}

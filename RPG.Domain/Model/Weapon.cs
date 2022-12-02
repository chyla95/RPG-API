using System.ComponentModel.DataAnnotations;

namespace RPG.Domain.Model
{
#pragma warning disable CS8618
    public class Weapon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Damage { get; set; }
    }
#pragma warning restore CS8618
}

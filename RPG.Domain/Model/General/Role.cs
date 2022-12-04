using System.ComponentModel.DataAnnotations;

namespace RPG.Domain.Model.General
{
#pragma warning disable CS8618
    public class Role : Entity
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        public IEnumerable<Staff> Staff { get; set; }

        // TODO: Add Premissions
    }
#pragma warning restore CS8618
}

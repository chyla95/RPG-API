using System.ComponentModel.DataAnnotations;

namespace RPG.Domain.Model.General
{
#pragma warning disable CS8618
    public class StaffMember : User
    {
        [Required]
        public IEnumerable<Role> Roles { get; set; }
    }
#pragma warning restore CS8618
}

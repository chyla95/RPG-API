using System.ComponentModel.DataAnnotations;

namespace RPG.Domain.Model.General
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}

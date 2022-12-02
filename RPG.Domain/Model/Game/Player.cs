using RPG.Domain.Model.General;

namespace RPG.Domain.Model.Game
{
#pragma warning disable CS8618
    public class Player : User
    {
        public ICollection<PlayerCharacter> Characters { get; set; }
    }
#pragma warning restore CS8618
}

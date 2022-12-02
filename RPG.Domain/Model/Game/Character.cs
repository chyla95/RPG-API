using System.ComponentModel.DataAnnotations;
using RPG.Domain.Model.General;

namespace RPG.Domain.Model.Game
{
#pragma warning disable CS8618
    public class Character : Entity
    {
        protected const int NUMBER_OF_STATISTICS = 4;
        protected const int STATISTIC_POINTS_PER_LEVEL = NUMBER_OF_STATISTICS * 2;

        [Required]
        [MinLength(2), MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Level { get; set; }
        public int HitPoints { get { return Stamina * 5; } }
        public int CriticalHitChancePercentage
        {
            get
            {
                int levelModifier = (int)Math.Round((double)Level / 4);
                if (levelModifier == 0) levelModifier = 1;
                return Luck / levelModifier;
            }
        }

        [Required]
        [Range(1, int.MaxValue)]
        public virtual int Attack { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public virtual int Defense { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public virtual int Stamina { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public virtual int Luck { get; set; }

        public Weapon? Weapon { get; set; }

        public int CalculateWeaponDamage(Character targetCharacter)
        {
            Random random = new();

            int damage = 0;
            damage += random.Next((Attack / 2), Attack);
            if (Weapon != null) damage += Weapon.Damage;
            damage -= random.Next((targetCharacter.Defense / 2), targetCharacter.Defense);

            int criticalHitRoll = random.Next(0, 100);
            bool isCriticalHit = criticalHitRoll < CriticalHitChancePercentage;
            if (isCriticalHit) damage *= 2;

            if (damage < 0) damage = 0;

            return damage;
        }
    }
#pragma warning restore CS8618

}

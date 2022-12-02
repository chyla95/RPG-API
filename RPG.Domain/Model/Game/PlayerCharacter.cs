using System.ComponentModel.DataAnnotations;

namespace RPG.Domain.Model.Game
{
#pragma warning disable CS8618
    public class PlayerCharacter : Character
    {
        //[Required]
        //public Player Player { get; set; }
        [Required]
        public Class Class { get; set; }

        public override int Attack { get { return base.Attack + Class.BaseAttack + (Level * Class.AttackLevelMultiplier); } }
        public override int Defense { get { return base.Defense + Class.BaseDefense + (Level * Class.DefenseLevelMultiplier); } }
        public override int Stamina { get { return base.Stamina + Class.BaseStamina + (Level * Class.StaminaLevelMultiplier); } }
        public override int Luck { get { return base.Luck + Class.BaseLuck + (Level * Class.LuckLevelMultiplier); } }

        [Range(0, int.MaxValue)]
        public int PvpFightCount { get; set; }
        [Range(0, int.MaxValue)]
        public int PvpWinCount { get; set; }
        [Range(0, int.MaxValue)]
        public int PvpLoseCount { get; set; }

        public int UnassignedStatisticPointsCount
        {
            get
            {
                int totalStatisticPointCount = STATISTIC_POINTS_PER_LEVEL * Level;
                int unassignedStatisticPointCount = totalStatisticPointCount;
                unassignedStatisticPointCount -= base.Attack;
                unassignedStatisticPointCount -= base.Defense;
                unassignedStatisticPointCount -= base.Stamina;
                unassignedStatisticPointCount -= base.Luck;

                return unassignedStatisticPointCount;
            }
        }

        private bool CanStatisticBeIncremented(int points)
        {
            if (points < 0) return false;
            if (points > UnassignedStatisticPointsCount) return false;
            return true;
        }
        public void AddAttack(int points)
        {
            bool canStatisticBeIncremented = CanStatisticBeIncremented(points);
            if (!canStatisticBeIncremented) throw new Exception("Statistic incrementation failed!");
            base.Attack += points;
        }
        public void AddDefense(int points)
        {
            bool canStatisticBeIncremented = CanStatisticBeIncremented(points);
            if (!canStatisticBeIncremented) throw new Exception("Statistic incrementation failed!");
            base.Defense += points;
        }
        public void AddStamina(int points)
        {
            bool canStatisticBeIncremented = CanStatisticBeIncremented(points);
            if (!canStatisticBeIncremented) throw new Exception("Statistic incrementation failed!");
            base.Stamina += points;
        }
        public void AddLuck(int points)
        {
            bool canStatisticBeIncremented = CanStatisticBeIncremented(points);
            if (!canStatisticBeIncremented) throw new Exception("Statistic incrementation failed!");
            base.Luck += points;
        }
    }
#pragma warning restore CS8618
}

using System.ComponentModel.DataAnnotations;

namespace RPG.Domain.Model.Game
{
#pragma warning disable CS8618
    public class NonPlayerCharacter : Character
    {
        [Required]
        public bool CanBeScaled { get; set; }

        public void ScaleLevel(int level)
        {
            if (!CanBeScaled) throw new Exception("This NPC cannot be scaled.");
            Level = level;
            base.Attack = ScaleStatistics(Attack, level);
            base.Defense = ScaleStatistics(Defense, level);
            base.Stamina = ScaleStatistics(Stamina, level);
            base.Luck = ScaleStatistics(Luck, level);
        }

        private int ScaleStatistics(int statistic, int level)
        {
            int scaledStatistics = statistic;
            scaledStatistics += (int)(level * (double)(STATISTIC_POINTS_PER_LEVEL) / NUMBER_OF_STATISTICS); // User added stats
            scaledStatistics += (int)(level * (double)(STATISTIC_POINTS_PER_LEVEL) / NUMBER_OF_STATISTICS); // Class stats lvl multiplier
            return scaledStatistics;
        }
    }
#pragma warning restore CS8618
}

namespace RPG.Domain.Model.Game
{
    public class Battle
    {
        public Character Attacker { get; private set; }
        public Character Defender { get; private set; }
        public Character? Winner { get; private set; }
        public Character? Loser { get; private set; }
        public bool IsTie { get; private set; } = false;
        public List<BattleTurn> BattleTurns { get; private set; } = new();

        public Battle(Character attacker, Character defender)
        {
            Attacker = attacker;
            Defender = defender;
            SimulateFight();
        }

        private void SimulateFight()
        {
            bool isFightInProgress = true;
            int attackerHitPoints = Attacker.HitPoints;
            int defenderHitPoints = Defender.HitPoints;

            while (isFightInProgress)
            {
                BattleTurn battleTurn = new BattleTurn(Attacker, Defender);
                BattleTurns.Add(battleTurn);

                defenderHitPoints -= battleTurn.AttackerDamage;
                attackerHitPoints -= battleTurn.DefenderDamage;

                if (defenderHitPoints <= 0 || attackerHitPoints <= 0)
                {
                    isFightInProgress = false;
                    if (defenderHitPoints <= 0 && attackerHitPoints > 0)
                    {
                        Winner = Attacker;
                        Loser = Defender;
                    }
                    if (attackerHitPoints <= 0 && defenderHitPoints > 0)
                    {
                        Winner = Defender;
                        Loser = Attacker;
                    }
                    if (attackerHitPoints <= 0 && defenderHitPoints <= 0)
                    {
                        IsTie = true;
                    }
                }
            }
        }
    }
}

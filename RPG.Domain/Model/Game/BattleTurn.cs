namespace RPG.Domain.Model.Game
{
    public class BattleTurn
    {
        private Character Attacker { get; set; }
        private Character Defender { get; set; }
        public int AttackerDamage { get; private set; }
        public int DefenderDamage { get; private set; }

        public BattleTurn(Character attacker, Character defender)
        {
            Attacker = attacker;
            Defender = defender;
            CalculateDamage();
        }

        private void CalculateDamage()
        {
            AttackerDamage = Attacker.CalculateWeaponDamage(Defender);
            DefenderDamage = Defender.CalculateWeaponDamage(Attacker);
        }
    }
}

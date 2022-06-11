namespace Combat
{
    public class Warrior : Hero
    {
        private void DoMeleeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);
        }

        public override void AddDamage(int damage)
        {

        }

        public override void DoAttack(IDoDamage opponent)
        {
            DoMeleeAttack(opponent);
        }

    }
}

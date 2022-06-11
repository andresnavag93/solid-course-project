namespace Combat
{
    public class Archer : Hero
    {

        private void DoRangeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);

        }
        public override void AddDamage(int damage)
        {
        }

        public override void DoAttack(IDoDamage opponent)
        {
            DoRangeAttack(opponent);
        }
    }
}

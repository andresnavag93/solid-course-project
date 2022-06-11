namespace Combat
{
    public abstract class Hero : IDoDamage
    {
        public abstract void AddDamage(int damage);

        public abstract void DoAttack(IDoDamage opponent);
    }
}

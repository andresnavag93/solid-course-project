
public abstract class AbstractHero : IAttacker, IDamageReceiver
{
    public abstract void AddDamage(int damage);

    public abstract void DoAttack(IDamageReceiver opponent);
}


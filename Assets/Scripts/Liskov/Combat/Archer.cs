
public class Archer : AbstractHero
{

    private void DoRangeAttack(IDamageReceiver opponent)
    {
        opponent.AddDamage(10);

    }
    public override void AddDamage(int damage)
    {
    }

    public override void DoAttack(IDamageReceiver opponent)
    {
        DoRangeAttack(opponent);
    }
}


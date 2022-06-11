
public class Warrior : AbstractHero
{
    private void DoMeleeAttack(IDamageReceiver opponent)
    {
        opponent.AddDamage(10);
    }

    public override void AddDamage(int damage)
    {

    }

    public override void DoAttack(IDamageReceiver opponent)
    {
        DoMeleeAttack(opponent);
    }

}



using UnityEngine;

namespace Combat
{
    public class Rogue : Hero
    {
        private void DoMeleeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);
        }

        private void DoRangeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);
        }

        public override void AddDamage(int damage)
        {

        }

        public override void DoAttack(IDoDamage opponent)
        {
            if (Random.Range(1, 100) > 50)
            {
                DoMeleeAttack(opponent);
            }
            else
            {
                DoRangeAttack(opponent);
            }
        }

    }
}

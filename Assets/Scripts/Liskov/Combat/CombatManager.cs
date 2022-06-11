using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class CombatManager
    {
        public void Simulate(List<Hero> team1, List<Hero> team2)
        {
            foreach (var hero in team1)
            {
                var opponent = team2[Random.Range(0, team2.Count - 1)];
                hero.DoAttack(opponent);
            }
        }
    }
}

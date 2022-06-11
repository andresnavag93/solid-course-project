using UnityEngine;
public class HealItem : Item
{
    [SerializeField] private int _heal;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<HealthController>();
        if (player)
        {
            player.Heal(_heal);
            Destroy(gameObject);
        }

    }
}

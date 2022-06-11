using UnityEngine;

/* Set permanent speed power up */
public class SpeedItem : AbstractItem
{
    [SerializeField] private float _speed;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<MovementController>();
        if (player)
        {
            player.SetSpeed(_speed);
            Destroy(gameObject);
        }

    }
}

using UnityEngine;

/* Set permanent speed power up */
public class SpeedItem : Item
{
    [SerializeField] private float _speed;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<MovementController>();
        if (player)
        {
            player.SetSpeed(_speed);
            Destroy(gameObject);
        }

    }
}

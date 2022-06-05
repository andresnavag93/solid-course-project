using UnityEngine;

/* Set permanent speed power up */
public class SpeedItem : MonoBehaviour
{
    private ItemsManager.ItemTypes type = ItemsManager.ItemTypes.PermanentSpeed;
    [SerializeField] private float _speed;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
        if (player)
        {
            player.SetSpeed(_speed);
            Destroy(gameObject);
        }
        
    }
}

using UnityEngine;
public class HealItem : AbstractItem
{
    [SerializeField] private int _healQuantity;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        var healComponent = other.collider.GetComponent<IHealReceiver>();
        if (healComponent != null)
        {
            healComponent.Heal(_healQuantity);
            Destroy(gameObject);
        }

    }
}

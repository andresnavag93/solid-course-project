using UnityEngine;
public class HealItem : Item
{
    [SerializeField] private int _heal;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var healComponent = other.collider.GetComponent<IHeal>();
        if (healComponent != null)
        {
            healComponent.Heal(_heal);
            Destroy(gameObject);
        }

    }
}

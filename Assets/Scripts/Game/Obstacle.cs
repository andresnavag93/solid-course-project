using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _speed = 3;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * (_speed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var doDamageComponent = other.collider.GetComponent<IDamageReceiver>();
        if (doDamageComponent != null)
        {
            // Add damage and destroy the object
            doDamageComponent.AddDamage(_damage);
            Destroy(gameObject);
        }
        else
        {
            // only destroy the object, is not a player
            Destroy(gameObject);
        }
    }
}

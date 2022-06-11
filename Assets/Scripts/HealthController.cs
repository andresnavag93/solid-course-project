using Unity.Mathematics;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerHud _playerHud;
    [SerializeField] private int _initialHealth = 100;

    private int _currentHealth;

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        _currentHealth = _initialHealth;
        _playerHud.SetHealth(_currentHealth.ToString());
        _animator.SetBool("IsDeath", false);
    }

    public void AddDamage(int damage)
    {
        // Update current health with the damage
        _currentHealth -= damage;
        // Update hud
        _playerHud.SetHealth(_currentHealth.ToString());

        // if is death then Game Over
        if (_currentHealth <= 0)
        {
            /* Is not a good idea to use singletons patter to do that because this makes it difficult to test,
             but for the purpose of this course will be enough. In future courses we will see how to improve it using MVVM pattern */
            GameManager.Instance.OnPlayerDeath();
            _animator.SetBool("IsDeath", true);
        }
    }

    public void Heal(int heal)
    {
        // Check that the health is in the limits
        _currentHealth = math.min(_currentHealth + heal, _initialHealth);
        _playerHud.SetHealth(_currentHealth.ToString());
    }
}

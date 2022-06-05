using Unity.Mathematics;
using UnityEngine;

/* Controls the player movement and player health */
public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerHud _playerHud;
    [SerializeField] private int _initialHealth = 100;
    [SerializeField] private float _speed = 1;

    private float _currentSpeed;
    private int _currentHealth;

    private void Awake()
    {
        Reset();
    }

    private void FixedUpdate()
    {
        // Check input
        var horizontal = Input.GetAxis("Horizontal");
        _animator.SetFloat("Horizontal", math.abs(horizontal));
        _spriteRenderer.flipX = horizontal < 0;
        var x = horizontal * _currentSpeed * Time.deltaTime;

        // Move according the input
        transform.Translate(x, 0.0f, 0.0f);
    }

    public void Reset()
    {
        _currentSpeed = _speed;
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

    public void SetSpeed(float speed)
    {
        _currentSpeed = speed;
    }
}

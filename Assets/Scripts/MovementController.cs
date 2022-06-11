using Unity.Mathematics;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed = 1;

    private float _currentSpeed;

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
        _animator.SetBool("IsDeath", false);
    }

    public void SetSpeed(float speed)
    {
        _currentSpeed = speed;
    }
}

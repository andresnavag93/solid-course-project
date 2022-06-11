using Unity.Mathematics;
using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed = 1;

    private float _currentSpeed;

    private bool _isDrunk;

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

        if (_isDrunk)
        {
            x *= -1;
        }

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

    public void SetDrunk(float duration)
    {
        _isDrunk = true;
        StartCoroutine(DisableDrunk(duration));
    }

    private IEnumerator DisableDrunk(float time)
    {

        yield return new WaitForSeconds(time);
        _isDrunk = false;
    }
}

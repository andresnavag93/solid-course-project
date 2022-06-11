using Unity.Mathematics;
using UnityEngine;

public class RegularMovable : IMovable
{

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;

    public void DoMove(float speed)
    {
        var horizontal = Input.GetAxis("Horizontal");
        _animator.SetFloat("Horizontal", math.abs(horizontal));
        _spriteRenderer.flipX = horizontal < 0;
        var x = horizontal * speed * Time.deltaTime;
        // Move according the input
        _transform.Translate(x, 0.0f, 0.0f);
    }

    public void Configure(Animator animator, SpriteRenderer spriteRenderer, Transform transform)
    {
        _animator = animator;
        _spriteRenderer = spriteRenderer;
        _transform = transform;
    }
}

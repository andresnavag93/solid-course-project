using UnityEngine;
public interface IMovement
{
    void DoMove(float speed);

    void Configure(Animator animator, SpriteRenderer spriteRenderer, Transform transform);
}

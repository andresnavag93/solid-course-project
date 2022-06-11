using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkItem : AbstractItem
{

    [SerializeField] private float _duration = 2f;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<MovementController>();
        if (player)
        {
            player.SetDrunk(_duration);
            Destroy(gameObject);
        }

    }
}

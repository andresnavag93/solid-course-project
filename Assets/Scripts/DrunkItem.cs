using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkItem : Item
{

    [SerializeField] private float _duration = 2f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<MovementController>();
        if (player)
        {
            player.SetDrunk(_duration);
            Destroy(gameObject);
        }

    }
}

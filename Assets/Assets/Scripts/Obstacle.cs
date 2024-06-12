using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : Colect
{
    private int damage = 1;
    public int GetDamageObstacle { get { return damage; } }
    public override void Collide()
    {
        Player.Instance.TakeDamage(damage);
    }
    private void Awake()
    {
        transform.position = Vector3.zero;
    }
}

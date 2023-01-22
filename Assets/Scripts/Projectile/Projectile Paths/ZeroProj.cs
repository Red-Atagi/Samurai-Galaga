using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroProj :  ProjectileMove
{
    public override Vector2 DetermineVelocity()
    {
        //velocity = Vector2.MoveTowards(transform.position, GameManager.Instance.player.GetPlayerLocation(), Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2)));
        //velocity = Vector2.MoveTowards(transform.position, GameManager.Instance.player.GetPlayerLocation(), velocity.magnitude * Time.fixedDeltaTime);

        return Vector2.zero;
    }
}

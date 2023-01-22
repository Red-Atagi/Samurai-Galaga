using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyAction
{
    //[SerializeField, Tooltip("The current velocity of the enemy")]
    protected Vector2 velocity = new Vector2();
    public override void CallAction()
    {
        velocity = DetermineVelocity();
        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0);
    }

    public virtual Vector2 DetermineVelocity()
    {
        return velocity;
    }
}

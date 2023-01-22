using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : EnemyMove
{
    [SerializeField, Tooltip("The maximum velocity of the enemy")]
    private float xVelocity;
    private bool alreadySetVelocity = false;
    public override Vector2 DetermineVelocity()
    {
        if(!alreadySetVelocity) {
            velocity.x = xVelocity;
            alreadySetVelocity = true;
        }
        if(Mathf.Abs(transform.position.x) >= GameManager.Instance.maxPosition.x){
            return new Vector2(-velocity.x, velocity.y);
        }
        else{
            return velocity;
        }
    }
}

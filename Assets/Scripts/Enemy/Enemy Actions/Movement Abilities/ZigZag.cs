using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : EnemyMove
{
    [SerializeField, Tooltip("The maximum velocity of the enemy")]
    private Vector2 maxVelocity;
    private bool alreadySetVelocity = false;
    public override Vector2 DetermineVelocity()
    {
        if(!alreadySetVelocity) {
            velocity = maxVelocity;
            alreadySetVelocity = true;
        }
        Vector2 finalVelocity = velocity;
        if(Mathf.Abs(transform.position.x) >= GameManager.Instance.maxPosition.x)
        {
            finalVelocity.x *= -1;
        }
        if (transform.position.y <= -1*GameManager.Instance.maxPosition.y + 2 || transform.position.y >= GameManager.Instance.maxPosition.y + 2)
        {
            finalVelocity.y *= -1;
        }

        return finalVelocity;
    }
}

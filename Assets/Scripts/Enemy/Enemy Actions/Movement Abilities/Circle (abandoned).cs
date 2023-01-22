using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : EnemyMove
{
    [SerializeField, Tooltip("The maximum velocity of the enemy")]
    private float angularVelocity;
    [SerializeField, Tooltip("The radius of the enemy's motion")]
    private float circleRadius;
    private bool alreadySetVelocity = false;
    private Vector2 startPosition;
    private Vector2 circleCenter;
    public override Vector2 DetermineVelocity()
    {
        if(!alreadySetVelocity) {
            startPosition = transform.position;
            circleCenter = new Vector2(startPosition.x - circleRadius, startPosition.y);
            alreadySetVelocity = true;
        }
        //Vector2 finalVelocity = velocity;

        Vector2 finalVelocity;
        float angle;
        float linearVelocityMagnitude = circleRadius * angularVelocity;
        if (transform.position.x > circleCenter.x)
        {
            angle = Mathf.Asin((transform.position.y - circleCenter.y) / circleRadius); //quadrants 1 and 4
            if (transform.position.y > circleCenter.y)
            {
                finalVelocity = new Vector2(Mathf.Sin(Mathf.PI / 2 - angle) * linearVelocityMagnitude, Mathf.Cos(Mathf.PI / 2 - angle) * linearVelocityMagnitude); //quadrant 1
            }
            else
            {
                finalVelocity = new Vector2(Mathf.Cos(Mathf.PI / 2 + angle) * linearVelocityMagnitude, Mathf.Sin(Mathf.PI / 2 + angle) * linearVelocityMagnitude); //quadrant 4
            }
        }
        else if (transform.position.y < circleCenter.y)
        {
            angle = Mathf.Asin(-1*(transform.position.y - circleCenter.y) / circleRadius); //quadrant 3
            finalVelocity = new Vector2(Mathf.Cos(Mathf.PI / 2 - angle) * linearVelocityMagnitude, -1* Mathf.Sin(Mathf.PI / 2 - angle) * linearVelocityMagnitude);
            //finalVelocity = new Vector2(-1 * angularVelocity * Mathf.Sin(angle), angularVelocity * Mathf.Cos(angle));
        }
        else
        {
            angle = Mathf.Asin((transform.position.x - circleCenter.x) / circleRadius);//quadrant 2
            finalVelocity = new Vector2(-1 * Mathf.Sin(Mathf.PI / 2 - angle) * linearVelocityMagnitude, -1 * Mathf.Cos(Mathf.PI / 2 - angle) * linearVelocityMagnitude);
            //finalVelocity = new Vector2(-1 * angularVelocity * Mathf.Sin(angle), angularVelocity * Mathf.Cos(angle));
        }
        Debug.Log(finalVelocity);
        Debug.Log(angle);
        return finalVelocity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : Ability
{
    private float inputX;
    private float velocity;
    [SerializeField, Tooltip("The maximum velocity for the player")]
    private float maxVelocity;

    public void MoveInputPressed(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    public override void CallAbility()
    {
        velocity = inputX * maxVelocity;
        Vector3 temp = transform.position;
        float maxP = GameManager.Instance.maxPosition.x;
        temp.x = Mathf.MoveTowards(temp.x, Mathf.Sign(velocity) * maxP, Mathf.Abs(velocity * Time.fixedDeltaTime));
        transform.position = temp;
    }

    public Vector2 FindPlayer()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

}

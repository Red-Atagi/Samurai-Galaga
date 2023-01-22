using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField, Tooltip("The scalar speed of the projectile")]
    protected float speedScalar = 5;
    [SerializeField]
    protected float deflectedTimesAsFast = 2;
    protected Vector2 velocity = new Vector2();

    private void Start()
    {
        velocity = ComputeVelocity(GameManager.Instance.player.GetPlayerLocation());
    }

    public void Move()
    {
        if (transform.GetComponent<ProjectileController>().deflection){
            Debug.Log("Deflecging!" + gameObject);
            Vector3 enemyPosition = transform.GetComponent<ProjectileController>().enemyLoc.position;
            Vector2 position = new Vector2(enemyPosition.x, enemyPosition.y);
            velocity = ComputeVelocity(position) * deflectedTimesAsFast;
            Debug.Log(velocity);
        }
        else
        {
            velocity = DetermineVelocity();
        }
        
        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0);
    }

    public Vector2 ComputeVelocity(Vector2 target)
    {
        //Vector2 target = GameManager.Instance.player.GetPlayerLocation();
        Vector2 pos = transform.position;
        Vector2 dist = target - pos;

        return dist.normalized * speedScalar;
    }

    public virtual Vector2 DetermineVelocity()
    {
        return velocity;
    }


}

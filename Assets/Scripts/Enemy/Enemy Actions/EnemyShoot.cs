using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : EnemyAction
{

    private float currentShootTime = 0;
    //The time until the enemy can fire next (similar to currentSwingTime for Deflect)

    private float maxShootTime = 5; 
    //the time in between projectile firings (sec)

    // Called once every frame during the enemy's FixedUpdate() call
    public override void CallAction()
    {
        
        //this should be assigned earlier but every time I tried it, it broke
        enemyColor shooterColor = GetComponent<EnemyController>().enemyColor;

        if (currentShootTime == 0)
        {
            currentShootTime = maxShootTime;
            if (shooterColor == enemyColor.Red)
            {
                GameObject proj = GameObject.Instantiate(GameManager.Instance.projectileTypes[(int)ProjectileTypes.HomingProj]);
                proj.transform.position = transform.position;
                //spawn homing projectile
                proj.GetComponent<ProjectileController>().Setup(transform);
                Debug.Log("Shooting homing");
                GetComponent<EnemyController>().projectiles.Add(proj);
            }
            else if (shooterColor == enemyColor.Blue)
            {
                GameObject proj = GameObject.Instantiate(GameManager.Instance.projectileTypes[(int)ProjectileTypes.StraightLineProj]);
                proj.transform.position = transform.position;
                //spawn straight line projectile
                proj.GetComponent<ProjectileController>().Setup(transform);
                Debug.Log("Shooting Straight Line");
                GetComponent<EnemyController>().projectiles.Add(proj);
            }

        }


        currentShootTime = Mathf.MoveTowards(currentShootTime, 0, Time.fixedDeltaTime);
    }
}
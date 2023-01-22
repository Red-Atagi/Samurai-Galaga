using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyColor {Red, Blue};

public class EnemyController : MonoBehaviour
{
    public List<GameObject> projectiles = new List<GameObject>();
    private EnemyAction[] enemyActions;
    public enemyColor enemyColor;

    void Start()
    {
        enemyActions = GetComponents<EnemyAction>();
    }

    void FixedUpdate()
    {
        foreach (EnemyAction eA in enemyActions)
        {
            eA.CallAction();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Blue Projectile" && other.gameObject.GetComponent<ProjectileController>().deflection && enemyColor == enemyColor.Blue)
        {
            foreach (GameObject projectile in projectiles)
            {
                GameObject.Destroy(projectile);
            }
            GameObject.Destroy(gameObject);
            GameManager.Instance.howManyEnemies--;
            GameManager.Instance.gameScore += 100;
        }
        else if (other.tag == "Red Projectile" && other.gameObject.GetComponent<ProjectileController>().deflection && enemyColor == enemyColor.Red)
        {
            foreach (GameObject projectile in projectiles)
            {
                GameObject.Destroy(projectile);
            }
            GameObject.Destroy(gameObject);
            GameManager.Instance.howManyEnemies--;
            GameManager.Instance.gameScore += 100;
        }

    }
}

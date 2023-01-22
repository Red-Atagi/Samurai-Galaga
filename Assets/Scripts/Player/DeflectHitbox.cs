using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectHitbox : MonoBehaviour
{
    [Tooltip("The current color of the sword. Serialized for debugging purposes only, not meant to be adjusted in the inspector.")]
    public enemyColor swordColor;

    // Make sure the sword hitbox isn't active when the game starts
    private void Start() {
        gameObject.SetActive(false); 
    }

    // If the sword hitbox hits a projectile, deflect the projectile
    private void OnTriggerStay2D(Collider2D collisionInfo)
    {
        Debug.Log(collisionInfo);
        ProjectileController projectile;
        if (collisionInfo.gameObject.TryGetComponent<ProjectileController>(out projectile) && projectile.projectileColor == swordColor)
        {
            projectile.Deflect();
        }
    }
}

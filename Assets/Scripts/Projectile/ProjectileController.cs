using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Transform enemyLoc;

    public bool deflection = false;

    public enemyColor projectileColor;
    private void FixedUpdate()
    {
        GetComponent<ProjectileMove>().Move();
    }

    public void Deflect()
    {
        deflection = true;
    }

    public void Setup(Transform enemyLocation)
    {
        enemyLoc = enemyLocation;
    }

}

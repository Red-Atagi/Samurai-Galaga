using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    private Ability[] abilities;
    [SerializeField]private int lives;
    public GameObject[] hearts;

    void Start()
    {
        abilities = GetComponents<Ability>();
        lives = 3;
    }

    void FixedUpdate()
    {
        foreach(Ability ability in abilities)
        {
            ability.CallAbility();
        }
        //Debug.Log(GetPlayerLocation());
    }
    public void TakeDamage ()
    {
        lives -= 1;
        hearts[lives].SetActive(false);
        if (lives == 0)
        {
            Death();
        }
    }
    void Death ()
    {
        //need game over screen
        Time.timeScale = 0;
    }

    public Vector2 GetPlayerLocation()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Red Projectile" || other.tag == "Blue Projectile")
            { 
                GameObject.Destroy(other.gameObject);
                TakeDamage();
            }
 
    }
}

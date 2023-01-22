using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Deflect : Ability
{
    [SerializeField, Tooltip("When enabled, a log of all actions related to this ability will print to the console")]
    private bool debug;
    [SerializeField, Tooltip("The child gameobject that contains the deflection hitbox")]
    private GameObject deflectHitbox;

    public Animator animator;

    private bool swordSwingPressed = false;

    [SerializeField, Tooltip("The time (s) the player has to deflect projectiles")]
    private float maxSwingTime;
    [SerializeField, Tooltip("The current time (s) of the sword swing (counting down). Serialized for debugging purposes only, not meant to be adjusted in the inspector.")]
    private float currentSwingTime = 0; //Where the player is in the process of swinging the sword (countdown)

    [SerializeField]
    private float noSwingTimer;
    private bool coolDown = false;

    public void SwordPressedRed(InputAction.CallbackContext context)
    {
        animator.Play("Swing Red");
        //animator.SetTrigger("SwingRed");
        swordSwingPressed = (context.ReadValue<float>() > 0.5f);
        if(swordSwingPressed && currentSwingTime == 0) { // Change the sword's color when you press the button while not already swinging the sword
            deflectHitbox.GetComponent<DeflectHitbox>().swordColor = enemyColor.Red;
            deflectHitbox.GetComponent<SpriteRenderer>().material.color = Color.red;
        }
        if(debug) {
            Debug.Log("Red button: " + swordSwingPressed);
        }
    }

    public void SwordPressedBlue(InputAction.CallbackContext context)
    {
        animator.Play("Swing Blue");
        //animator.SetTrigger("SwingBlue");
        swordSwingPressed = (context.ReadValue<float>() > 0.5f);
        if(swordSwingPressed && currentSwingTime == 0) { // Change the sword's color when you press the button while not already swinging the sword
            deflectHitbox.GetComponent<DeflectHitbox>().swordColor = enemyColor.Blue;
            deflectHitbox.GetComponent<SpriteRenderer>().material.color = Color.blue;
        }
        if (debug) {
            Debug.Log("Blue button: " + swordSwingPressed);
        }
    }

    // Called once every frame during the player's FixedUpdate() call
    public override void CallAbility()
    {
        //resets cooldown for sword
        if (swordSwingPressed && currentSwingTime == 0 && !coolDown)
        {
            StartCoroutine(CooldownTimer());
            currentSwingTime = maxSwingTime;
            deflectHitbox.SetActive(true);
            if(debug) {
                Debug.Log("Sword hitbox enabled!");
            }
            
            swordSwingPressed = false; // Disabled the button input so the player can't repeatedly swing by holding down the button
        }

        //disables deflectHitbox if the sword isn't being used
        else if (currentSwingTime == 0 && deflectHitbox.activeSelf)
        {
            deflectHitbox.SetActive(false);
            if(debug) {
                Debug.Log("Sword hitbox disabled!");
            }
        }

        //Cooldown for sword swing (timer)
        currentSwingTime = Mathf.MoveTowards(currentSwingTime, 0, Time.fixedDeltaTime);

        
        //check if player is currently being hit by a projectile
        //check color of projectile
        //if player sword color and projectile color are the same, 
        //  deflect projectile to the enemy that created it
        //else player gets hit
        

    }

    private IEnumerator CooldownTimer ()
    {
        coolDown = true;
        yield return new WaitForSeconds(noSwingTimer);
        coolDown = false;
    }
}
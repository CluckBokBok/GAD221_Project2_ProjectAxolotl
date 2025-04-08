using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuddyPuddle : MonoBehaviour
{
    #region Variables

    [Header("Damage")]
    [Tooltip("The amount damage that will be inflicted to the player")]
    public int amountDamage; // used for the amount of damage - NOTE - change this in the inspector

    [Header("References")]
    [SerializeField] private PlayerHealth playerHealth; // reference
    [SerializeField] private FloatController playerMovement; // reference

    #endregion


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // check if its the player
        {

            if (playerHealth == null)
            {
                //Debug.Log("getting reference");
                playerHealth = FindObjectOfType<PlayerHealth>(); // get reference to player health               
            }

            if (playerMovement == null)
            {
                //Debug.Log("getting reference");
                playerMovement = FindObjectOfType<FloatController>();
            }

            //Debug.Log("dealing [" + amountDamage + "] damage");
            playerHealth.ChangePlayerHealth(amountDamage); // deal the damage 

            //Debug.Log("puddle slow");
            playerMovement.speed = 200f;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // check if its the player
        {
            //Debug.Log("puddle unslow");
            playerMovement.speed = 350f;
        }
    }
    

}

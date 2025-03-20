using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    [Header("Damage")]
    [Tooltip("The amount damage that will be inflicted")]
    public int amountDamage; // used for the amount of damage - NOTE - change this in the inspector

    [Header("References")]
    [SerializeField] private PlayerHealth playerHealth; // reference


    void Start()
    {
        //Debug.Log("this hazard will deal [" + amountDamage + "] damage"); 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // check if its the player
        {

            if (playerHealth == null)
            {
                //Debug.Log("getting reference");
                playerHealth = FindObjectOfType<PlayerHealth>(); // get reference to player health               
            }

            //Debug.Log("dealing [" + amountDamage + "] damage");
            playerHealth.ChangePlayerHealth(amountDamage); // deal the damage 

        }
    }

}

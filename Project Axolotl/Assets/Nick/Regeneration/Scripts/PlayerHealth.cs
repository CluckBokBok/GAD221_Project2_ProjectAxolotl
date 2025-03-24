using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// used to regenerate the players health overtime (axolotl)

public class PlayerHealth : MonoBehaviour
{

    #region Variables

    [Header("Health")]
    [Tooltip("The current player health")]
    public int health; // player health
    public int maxHealthAllowed = 5; // the allowed maximum health the player can have
    // IMPORTANT - keep health value in single digit or the UI will not align

    [Header("Regeneration")]
    public float regenerationTimer = 10.0f;
    public float regenerationTimeToCount = 10f;

    [Header("Timer")]
    [Tooltip("if true countdown, if false dont countdown")]
    public bool canCount; // wether the timer is active or deactive

    [Header("References")]
    public TextMeshProUGUI healthText; // Health UI
    public TextMeshProUGUI maxHealthText; // Max Health UI

    #endregion

    private void Start()
    {
        regenerationTimer = 0f; // testing timer
        maxHealthAllowed = 5; // testing max health
        health = 3; // testing health

        canCount = true;
        UpdatePlayerHealthUI();
        //Debug.Log("end of start");
    }

    void Update()
    {
        if (canCount == true && health < maxHealthAllowed) // needs to be able to count down (bool) and less than the max health allowed
        {
            regenerationTimer += Time.deltaTime;
        }

        if (regenerationTimer >= regenerationTimeToCount) // when the timer reaches the end
        {
            timerEnded();
            Debug.Log("Time Ended");
        }

    }

    public void timerEnded() // occurs when the timer hits 0
    {
        //Debug.Log("Time Ended");

        regenerationTimeToCount += 5f; // add to time the timer
        ResetRegenerationTimer(); // reset timer

        ChangePlayerHealth(1); // give the player health
    }

    public void ChangePlayerHealth(int healthAmount) //  change player health, NOTE - can also pass through a negative number 
    {
        Debug.Log("Adding [" + healthAmount + "] Health");
        health += healthAmount;
        

        #region Health Limits
        if (health > maxHealthAllowed)
        {
            health = maxHealthAllowed;
            Debug.Log("health exceeded limit");
        }
        if (health <= 0)
        {
            health = 0;
            Debug.Log("health went below 0");
        }
        #endregion

        UpdatePlayerHealthUI(); // after health value is changed instantly update the UI
    }

    public void ResetRegenerationTimer() // resets the timer
    {
        regenerationTimer = 0;

        //Debug.Log("reset regen timer");

    }

    public void ToggleTimer() // used to turn off and on the timer
    {
        
        if (canCount == true)
        {
            canCount = false;
        }

        else if (canCount == false)
        {
            canCount = true;
        }

        //Debug.Log("time toggle");

    }

    public void UpdatePlayerHealthUI() // update player health UI
    {
        healthText.text = health.ToString();
        maxHealthText.text = maxHealthAllowed.ToString();

        //Debug.Log("health UI updated");

    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public float regenerationTimer = 0f; // timer
    public float regenerationTimeToCount = 10f; // timer to count to

    [SerializeField] private int amountOfTimesRegenerated = 0; // keep at 0
    public int maxAmountOfRegen = 5; // max amount of times player can regen

    [Header("Timer")]
    [Tooltip("if true countdown, if false dont countdown")]
    public bool canCount; // wether the timer is active or deactive

    [Header("References")]
    public TextMeshProUGUI healthText; // Health UI
    public TextMeshProUGUI maxHealthText; // Max Health UI
    public GameObject damageIndicatorFlash; // Red Damage Effect Image
    public GameObject regenIndicatorFlash; // Regeneration Effect Image

    [SerializeField] private SceneManagement SceneChanger; // reference

    #endregion

    private void Start()
    {
        regenerationTimer = 0f; // reset time

        maxHealthAllowed = 5; // testing max health
        health = 4; // testing health

        canCount = true;
        UpdatePlayerHealthUI();
        //Debug.Log("end of start");
        SceneChanger = FindObjectOfType<SceneManagement>();

    }

    void Update()
    {
        if (canCount == true && health < maxHealthAllowed) // needs to be able to count down (bool) and less than the max health allowed
        {
            if (amountOfTimesRegenerated < maxAmountOfRegen)
            {
                regenerationTimer += Time.deltaTime;
            }          
        }

        if (regenerationTimer >= regenerationTimeToCount) // when the timer reaches the end 
        {
            timerEnded();
            Debug.Log("Time Ended");
        }

    }

    public void timerEnded() // occurs when the timer is reached
    {
        //Debug.Log("Time Ended");

        regenerationTimeToCount += 2f; // add to time the timer
        amountOfTimesRegenerated += 1;

        ResetRegenerationTimer(); // reset timer

        ChangePlayerHealth(1); // give the player health
    }

    public void ChangePlayerHealth(int healthAmount) //  change player health, NOTE - can also pass through a negative number 
    {
        Debug.Log("Adding [" + healthAmount + "] Health");
        health += healthAmount;
        
        if (healthAmount < 0)
        {
            DamageIndicator();
        }

        if (healthAmount > 0)
        {
            StartCoroutine(RegenerationEffect());
        }

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
            SceneChanger.LoadSceneByName("Death Scene");

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

    public void DamageIndicator() // used for damage indication
    {
        //Debug.Log("start damage effect");
        StartCoroutine(DamageEffect()); // play damage effect
        
        
    }

    IEnumerator DamageEffect()
    {
        //Debug.Log("activating red effect");
        damageIndicatorFlash.SetActive(true); // turns on the damage effect

        yield return new WaitForSeconds(0.75f); // wait

        damageIndicatorFlash.SetActive(false); // turns off the damage effect
    }

    IEnumerator RegenerationEffect()
    {
        //Debug.Log("activating red effect");
        regenIndicatorFlash.SetActive(true); // turns on the regen effect

        yield return new WaitForSeconds(0.75f); // wait

        regenIndicatorFlash.SetActive(false); // turns off the regen effect
    }


}

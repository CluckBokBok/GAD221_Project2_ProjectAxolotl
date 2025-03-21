using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegenerationSlider : MonoBehaviour
{

    #region Variables

    [Header("References")]
    public Image timerBar; // image/bar to shrink
    [SerializeField] private PlayerHealth pHealth;

    #endregion

    void Start()
    {
        pHealth = FindObjectOfType<PlayerHealth>(); // get referemce
        pHealth.regenerationTimer = pHealth.regenerationTimeToCount; // start timer
    }

    void Update()
    {
        if (pHealth.regenerationTimer > 0) // change bar
        {
            timerBar.fillAmount = pHealth.regenerationTimer / pHealth.regenerationTimeToCount; // reduce size bar
        }

        else if (pHealth.regenerationTimer <= 0) // when bar reaches 0
        {
            //Debug.Log("reset timer");
            pHealth.regenerationTimer = pHealth.regenerationTimeToCount; // reset
        }

    }
}

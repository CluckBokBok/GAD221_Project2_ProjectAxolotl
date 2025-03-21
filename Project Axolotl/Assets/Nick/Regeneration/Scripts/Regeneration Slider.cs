using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegenerationSlider : MonoBehaviour
{
    public Image timerBar;
    [SerializeField] private PlayerHealth pHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pHealth = FindObjectOfType<PlayerHealth>();
        pHealth.regenerationTimer = pHealth.regenerationTimeToCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (pHealth.regenerationTimer > 0)
        {
            pHealth.regenerationTimer -= Time.deltaTime;
            timerBar.fillAmount = pHealth.regenerationTimer / pHealth.regenerationTimeToCount;
        }

        else if (pHealth.regenerationTimer <= 0)
        {
            pHealth.regenerationTimer = pHealth.regenerationTimeToCount;
        }

    }
}

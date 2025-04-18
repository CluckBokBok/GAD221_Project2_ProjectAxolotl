using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeCollider : MonoBehaviour
{

    #region Variables



    [Header("References")]
    [SerializeField] private SceneManagement SceneChanger; // reference
    [SerializeField] private AxolotlRescuezone AxolotlRescue;

    [SerializeField] private GameObject escapeUI; // UI to ask if they want to escape - place the UI in the inspector

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        SceneChanger = FindObjectOfType<SceneManagement>();
        AxolotlRescue = FindObjectOfType<AxolotlRescuezone>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // check if its the player
        {
            if (AxolotlRescue.rescuecount >= 6)
            {
                //Debug.Log("all axolotls found! leaving.");
                SceneChanger.LoadSceneByName("Escape Scene");
            }

            else
            {
                if (escapeUI != null) // make sure variable is not empty
                {
                    //Debug.Log("are you sure you want to leave?");
                    escapeUI.SetActive(true); // ask if they are sure, if yes load "Escape Scene" through the UI
                }
            }


        }
    }

}

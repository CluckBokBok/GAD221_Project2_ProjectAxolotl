using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Axolotlnpc : MonoBehaviour
{
    
    private bool axoTutorial = true;
    private infoUI infoUI;
    [SerializeField] Sprite axoTutorialSprite;
    
    private Vector3 Followtarget;
    [SerializeField] private bool follow = false;
    private FloatController player;
    private Vector3 offset;
    public bool rescued = false;

    public float detectrange = 2f;
    //[SerializeField] private float distance = 1.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FloatController>();
        infoUI = GameObject.FindGameObjectWithTag("Player").GetComponent<infoUI>();
    }

    public void ToggleFollow()
    {
        follow = !follow;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<infoUI>().axolotlUI.axolotlsaved > 0)
            {
                axoTutorial = false;
            }
            if (axoTutorial)
            {
                axoTutorial = false;
                infoUI.PanelUpdate("Save the Axolotls!", "Press E to lead them to the Extraction zone!",
                    axoTutorialSprite, "Find them all!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space) && Vector2.Distance(transform.position, player.transform.position) < detectrange)
        {
            ToggleFollow();
        } */

       //Placeholder
       if (Input.GetKeyDown(KeyCode.E)&& Vector2.Distance(transform.position, player.transform.position) < detectrange)
       {
           follow = true;
       }
       
       if (Input.GetKeyDown(KeyCode.Q)&& Vector2.Distance(transform.position, player.transform.position) < detectrange)
       {
           follow = false;
       }
       
        if (follow)
        {
            Follow();
        }
        else
        {
            Stay();
        }
        
        
        if (player.rb.velocity.magnitude > 0.5f)
        {
            offset = Vector3.Normalize(player.rb.velocity * -1);
        }
        
    }

    void Follow()
    {
        Followtarget = player.transform.position;
        transform.position = Vector2.Lerp( transform.position , Followtarget + offset, Time.deltaTime * 10);
    }

    void Stay()
    {
        Followtarget = transform.position;
    }
}

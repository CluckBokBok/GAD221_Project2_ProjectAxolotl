using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FloatController : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    //public float detectrange = 1f;
    //private Axolotlnpc[] axolotlnpcs;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //axolotlnpcs = FindObjectsOfType<Axolotlnpc>();
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<Axolotlnpc>() != null)
        {
            Debug.Log("NPC found");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                other.gameObject.GetComponent<Axolotlnpc>().ToggleFollow();
            }

            //interact
        }
    } */
    
    
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        
        
        
        rb.AddForce(new Vector2(h, v) * speed, ForceMode2D.Force);

        
    }
}

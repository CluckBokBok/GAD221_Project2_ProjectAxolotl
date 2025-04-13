using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infozone : MonoBehaviour
{
    public string title;
    public string description;
    public Sprite image;
    public string imagedesc;

    private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !activated)
        {
          infoUI ui = other.GetComponent<infoUI>();
          ui.PanelUpdate(title, description, image, imagedesc);
          activated = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
